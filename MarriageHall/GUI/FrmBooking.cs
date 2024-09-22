using MarriageHall.BLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace MarriageHall.GUI
{
    public partial class FrmBooking : Form
    {
        public Account LoginAccount { get; set; }
        public Customer Customer { get; set; }

        public FrmBooking(Account account, Customer customer)
        {
            InitializeComponent();
            LoginAccount = account;
            Customer = customer;
            txtCustomerName.Text = customer.Name;
            txtCustomerPhone.Text = customer.Phone;
            InitConfig();
        }

        List<BookingDetail> bookingDetails = new List<BookingDetail>();
        int numberOfTables = 1;
        decimal totalPricePerTable = 0;
        decimal hallPrice = 0;
        decimal discount = 0;
        decimal totalPrice = 0;

        private void FrmBooking_Load(object sender, System.EventArgs e)
        {
            LoadListCategory();
            LoadListItem();
        }

        private void InitConfig()
        {
            lsvBill.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvBill.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            dtpkHallServiceDate.MinDate = DateTime.Today.AddDays(1);
            dtpkHallServiceDate.Value = DateTime.Today.AddDays(1); 
            nmDiscount.Value = discount;
            txtTotalPricePerTable.Text = totalPricePerTable.ToString("c");
            txtSelectHallPrice.Text = hallPrice.ToString("c");
            txtTotalPrice.Text = hallPrice.ToString("c");
        }

        private void LoadListCategory()
        {
            cboCategory.DataSource = BLLCategory.Instance.GetListCategory();
            cboCategory.ValueMember = "Id";
            cboCategory.DisplayMember = "Name";
        }

        private void LoadListItem()
        {
            bool hasCategoryId = int.TryParse(cboCategory.SelectedValue.ToString(), out int categoryId);
            if (!hasCategoryId)
            {
                return;
            }
            cboItem.DataSource = BLLItem.Instance.GetItemByCategoryId(categoryId);
            cboItem.ValueMember = "Id";
            cboItem.DisplayMember = "Name";
            txtItemPrice.DataBindings.Clear();
            txtItemPrice.DataBindings.Add(new Binding("Text", cboItem.DataSource, "Price"));
        }

        private void cboCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadListItem();
        }

        private void ShowBill()
        {
            lsvBill.Items.Clear();
            foreach (var bookingDetail in bookingDetails)
            {
                ListViewItem listViewItem = new ListViewItem(bookingDetail.ItemName);
                listViewItem.SubItems.Add(bookingDetail.Price.ToString("c"));
                listViewItem.SubItems.Add(bookingDetail.Quantity.ToString());
                listViewItem.SubItems.Add(bookingDetail.TotalPrice.ToString("c"));
                lsvBill.Items.Add(listViewItem);
            }
            CalcTotalPrice();
        }

        private void btnAddItem_Click(object sender, System.EventArgs e)
        {
            int itemId = (int)cboItem.SelectedValue;
            string itemName = cboItem.Text;
            int quantity = (int)nmItemQuantity.Value;
            decimal price = decimal.Parse(txtItemPrice.Text);

            if (bookingDetails.Any(x => x.ItemId == itemId))
            {
                var bookingDetail = bookingDetails.First(x => x.ItemId == itemId);
                bookingDetail.Quantity += quantity;
                if (bookingDetail.Quantity <= 0)
                {
                    bookingDetails.Remove(bookingDetail);
                }
            }
            else if (quantity > 0)
            {
                BookingDetail bookingDetail = new BookingDetail();
                bookingDetail.ItemId = itemId;
                bookingDetail.ItemName = itemName;
                bookingDetail.Quantity = quantity;
                bookingDetail.Price = price;

                bookingDetails.Add(bookingDetail);
            }
            ShowBill();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            int itemId = (int)cboItem.SelectedValue;
            if (bookingDetails.Any(x => x.ItemId == itemId))
            {
                var bookingDetail = bookingDetails.First(x => x.ItemId == itemId);
                bookingDetails.Remove(bookingDetail);
            }
            ShowBill() ;
        }

        private void CalcTotalPrice()
        {
            totalPricePerTable = 0;
            foreach (var bookingDetail in bookingDetails)
            {
                totalPricePerTable += bookingDetail.TotalPrice;
            }
            totalPrice = totalPricePerTable * numberOfTables;
            totalPrice += hallPrice;
            totalPrice *= (1 - discount / 100);

            txtTotalPricePerTable.Text = totalPricePerTable.ToString("c");
            txtTotalPrice.Text = totalPrice.ToString("c");
        }

        private void LoadListHall()
        {
            DateTime dateTime = dtpkHallServiceDate.Value;
            cboHall.DataSource = BLLHall.Instance.GetHallAvailableByDate(dateTime);
            if (cboHall.Items.Count == 0)
            {
                txtHallPrice.Text = "0";
                cboHall.Text = "Hết sảnh";
            }
            cboHall.ValueMember = "Id";
            cboHall.DisplayMember = "Name";
            txtHallPrice.DataBindings.Clear();
            txtHallPrice.DataBindings.Add(new Binding("Text", cboHall.DataSource, "Price"));
            txtHallNumberOfTables.DataBindings.Clear();
            txtHallNumberOfTables.DataBindings.Add(new Binding("Text", cboHall.DataSource, "NumberOfTables"));
        }

        private void LoadListShift()
        {
            if (cboHall.Items.Count == 0)
            {
                cboShift.DataSource = null;
                cboShift.Items.Clear();
                cboShift.Text = "Hết ca";
                return;
            }
            DataTable dt = BLLHall.Instance.GetShiftUnavailableByDate((int)cboHall.SelectedValue, dtpkHallServiceDate.Value); 
            var shiftUnavailable = dt.Rows.OfType<DataRow>().Select(r => int.Parse((r.Field<object>("Shift").ToString()))).ToList();
            cboShift.DataSource = EnumExtension.GetListDescriptions<ShiftEnum>().Where(x => !shiftUnavailable.Contains(x.Key)).ToList();
            cboShift.DisplayMember = "Value";
            cboShift.ValueMember = "Key";
        }

        private void dtpkHallServiceDate_ValueChanged(object sender, EventArgs e)
        {
            LoadListHall();
            LoadListShift();
        }

        private void btnSelectHall_Click(object sender, EventArgs e)
        {
            if (cboHall.Items.Count == 0)
            {
                txtSelectDate.Text = string.Empty;
                txtSelectHallName.Text = string.Empty;
                txtSelectShift.Text = string.Empty;
                txtSelectHallPrice.Text = 0.ToString("c");
                hallPrice = 0;
            } 
            else
            {
                txtSelectDate.Text = dtpkHallServiceDate.Value.ToString("yyyy-MM-dd");
                txtSelectShift.Text = cboShift.Text;
                txtSelectHallName.Text = cboHall.Text;
                hallPrice = decimal.Parse(txtHallPrice.Text);
                txtSelectHallPrice.Text = hallPrice.ToString("c");
            }
            CalcTotalPrice();
        }

        private void txtHallNumberOfTables_TextChanged(object sender, EventArgs e)
        {
            nmNumberOfTables.Maximum = int.Parse(txtHallNumberOfTables.Text);
        }

        private void nmDiscount_ValueChanged(object sender, EventArgs e)
        {
            discount = nmDiscount.Value;
            CalcTotalPrice();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            if (!string.IsNullOrEmpty(txtSelectShift.Text))
            {
                booking.HallId = (int)cboHall.SelectedValue;
                booking.ServiceDate = dtpkHallServiceDate.Value;
                booking.Shift = (ShiftEnum)cboShift.SelectedValue;
            }
            booking.CustomerId = Customer.Id;
            booking.StaffId = LoginAccount.Id;
            booking.NumberOfTables = (int)nmNumberOfTables.Value;
            booking.Note = txtNote.Text;
            booking.Discount = discount;
            booking.TotalPrice = totalPrice;
            booking.IsPaid = ckbIsPaid.Checked;

            try
            {
                if (BLLBooking.Instance.Validate(booking))
                {
                    if (MessageBox.Show("Bạn có chắc muốn đặt tiệc?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                    if (BLLBooking.Instance.InsertBooking(booking))
                    {
                        int bookingId = BLLBooking.Instance.GetBookingId(booking.HallId, booking.Shift, booking.ServiceDate.DateTime);
                        foreach (var bookingDetail in bookingDetails)
                        {
                            bookingDetail.BookingId = bookingId;
                            BLLBookingDetail.Instance.InsertBookingDetail(bookingDetail);
                        }
                        MessageBox.Show("Đặt tiệc thành công", "Thông báo");
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMomo_Click(object sender, EventArgs e)
        {
            if (totalPrice == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thanh toán", "Thông báo");
                return;
            }
            Form frmQRCode = new Form();
            frmQRCode.MaximizeBox = false;
            frmQRCode.MinimizeBox = false;
            frmQRCode.StartPosition = FormStartPosition.CenterScreen;
            frmQRCode.AutoSize = true;
            frmQRCode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            frmQRCode.Text = "Thanh toán Momo";

            PictureBox pbQRCode = new PictureBox();
            pbQRCode.SizeMode = PictureBoxSizeMode.AutoSize;
            var qrcode_text = $"2|99|0973054202|NGUYEN ANH DUC|ducna0610@gmail.com|0|0|{totalPrice}";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 250, Height = 250, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrcode_text);
            Bitmap logo = ResizeImage(Properties.Resources.momo, 64, 64) as Bitmap;
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
            pbQRCode.Image = bitmap;

            frmQRCode.Controls.Add(pbQRCode);
            frmQRCode.ShowDialog();
        }

        private Image ResizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private void nmNumberOfTable_ValueChanged(object sender, EventArgs e)
        {
            numberOfTables = (int)nmNumberOfTables.Value;
            CalcTotalPrice();
        }

        private void btnDeleteHall_Click(object sender, EventArgs e)
        {
            hallPrice = 0;
            txtSelectDate.Clear();
            txtSelectShift.Clear();
            txtSelectHallName.Clear();
            txtSelectHallPrice.Text = hallPrice.ToString("c");

            CalcTotalPrice();
        }
    }
}
