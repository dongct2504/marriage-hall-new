using MarriageHall.BLL;
using MarriageHall.DTO;
using MarriageHall.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarriageHall.GUI
{
    public partial class FrmBookingDetail : Form
    {
        public int BookingId { get; set; }

        public FrmBookingDetail(int bookingId)
        {
            InitializeComponent();
            BookingId = bookingId;
            lsvBill.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvBill.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            cboStatus.DataSource = EnumExtension.GetListDescriptions<StatusEnum>();
            cboStatus.ValueMember = "Key";
            cboStatus.DisplayMember = "Value";
        }

        private void FrmBookingDetail_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadStaff();
            LoadHall();
            LoadBooking();
            LoadListBookingDetail();
        }

        private void LoadCustomer()
        {
            Customer customer = BLLCustomer.Instance.GetCustomerByBookingId(BookingId);
            txtCustomerName.Text = customer.Name;
            txtCustomerPhone.Text = customer.Phone;
        }

        private void LoadStaff()
        {
            Account staff = BLLAccount.Instance.GetAccountByBookingId(BookingId);
            txtStaffName.Text = staff.Name;
            txtStaffUserName.Text = staff.UserName;
        }

        private void LoadHall()
        {
            Hall hall = BLLHall.Instance.GetHallByBookingId(BookingId);
            txtHallName.Text = hall.Name;
            txtHallPrice.Text = hall.Price.ToString("c");
        }

        private void LoadBooking()
        {
            Booking booking = BLLBooking.Instance.GetBookingById(BookingId);
            txtBookingId.Text = booking.Id.ToString();
            txtServiceDate.Text = booking.ServiceDate.ToString("d");
            txtShift.Text = EnumExtension.GetDescription(booking.Shift);
            txtNumberOfPeople.Text = booking.NumberOfPeople.ToString();
            txtCreatedAt.Text = booking.CreatedAt.ToString("d");
            txtNote.Text = booking.Note;
            txtDiscount.Text = booking.Discount.ToString();
            txtTotalPrice.Text = booking.TotalPrice.ToString("c");
            cboStatus.SelectedValue = (int)booking.Status;
            ckbIsPaid.Checked = booking.IsPaid;
        }

        private void LoadListBookingDetail()
        {
            List<BookingDetail> listBookingDetail = BLLBookingDetail.Instance.GetListBookingDetailByBookingId(BookingId);

            foreach (BookingDetail bookingDetail in listBookingDetail)
            {
                ListViewItem listViewItem = new ListViewItem(bookingDetail.ItemName);
                listViewItem.SubItems.Add(bookingDetail.Price.ToString("c"));
                listViewItem.SubItems.Add(bookingDetail.Quantity.ToString());
                listViewItem.SubItems.Add(bookingDetail.TotalPrice.ToString("c"));
                lsvBill.Items.Add(listViewItem);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int isPaid = ckbIsPaid.Checked ? 1 : 0;
                int status = (int)cboStatus.SelectedValue;
                string note = txtNote.Text;
                if (BLLBooking.Instance.UpdateBooking(BookingId, isPaid, status, note))
                {
                    MessageBox.Show("Cập nhật đơn hàng thành công", "Thông báo");
                    Booking booking = BLLBooking.Instance.GetBookingById(BookingId);
                    updateBooking(this, new BookingEvent(booking));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private event EventHandler<BookingEvent> updateBooking;
        public event EventHandler<BookingEvent> UpdateBooking
        {
            add { updateBooking += value; }
            remove { updateBooking -= value; }
        }
    }

    public class BookingEvent : EventArgs
    {
        public Booking Booking { get; set; }

        public BookingEvent(Booking booking)
        {
            Booking = booking;
        }
    }
}
