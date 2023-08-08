using System;

namespace MyApp
{
    // tạo lớp thời gian
    public class ThoiGian
    {
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public int gio { get; set; }
        public int phut { get; set; }
        public int giay { get; set; }

        // hàm khởi tạo có tham số
        public ThoiGian(int data_ngay = 1,
                        int data_thang = 1,
                        int data_nam = 1,
                        int data_gio = 0,
                        int data_phut = 0,
                        int data_giay = 0)
        {
            ngay = data_ngay;
            thang = data_thang;
            nam = data_nam;
            gio = data_gio;
            phut = data_phut;
            giay = data_giay;
        }

        // nạp chồng phương thức ToString
        public string ToString(string dinh_dang = "")
        {
            string str_ngay = ngay.ToString();
            string str_thang = thang.ToString();
            string str_nam = nam.ToString();
            string str_gio = gio.ToString();
            string str_phut = phut.ToString();
            string str_giay = giay.ToString();

            if (ngay < 10)
            {
                str_ngay = "0" + str_ngay;
            }

            if (thang < 10)
            {
                str_thang = "0" + str_thang;
            }

            if (str_nam.Length <= 1)
            {
                str_nam = "000" + str_nam;
            }
            else if (str_nam.Length <= 2)
            {
                str_nam = "00" + str_nam;
            }
            else if (str_nam.Length <= 3)
            {
                str_nam = "0" + str_nam;
            }

            if (str_gio.Length <= 1)
            {
                str_gio = "0" + str_gio;
            }

            if (str_phut.Length <= 1)
            {
                str_phut = "0" + str_phut;
            }

            if (str_giay.Length <= 1)
            {
                str_giay = "0" + str_giay;
            }

            // tạo biến kết quả
            string ketQua = $"{str_ngay}/{str_thang}/{str_nam} {str_gio}:{str_phut}:{str_giay}";

            if (dinh_dang.ToLower() == "dd/mm/yyyy")
            {
                ketQua = $"{str_ngay}/{str_thang}/{str_nam}"; ;
            }
            else if (dinh_dang.ToLower() == "dd/mm/yyyy hh:mm")
            {
                ketQua = $"{str_ngay}/{str_thang}/{str_nam} {str_gio}:{str_phut}";
            }
            else if (dinh_dang.ToLower() == "dd/mm/yyyy hh:mm:ss")
            {
                ketQua = $"{str_ngay}/{str_thang}/{str_nam} {str_gio}:{str_phut}:{str_giay}";
            }
            else if (dinh_dang.ToLower() == "yyyy/mm/dd")
            {
                ketQua = $"{str_nam}/{str_thang}/{str_ngay}";
            }
            else if (dinh_dang.ToLower() == "hh:mm:ss")
            {
                ketQua = $"{str_gio}:{str_phut}:{str_giay}";
            }
            else if (dinh_dang.ToLower() == "hh:mm")
            {
                ketQua = $"{str_gio}:{str_phut}";
            }
            else if (dinh_dang.ToLower() == "mm:ss")
            {
                ketQua = $"{str_phut}:{str_giay}";
            }

            return ketQua;
        }

        // hàm trả về ngày mai
        public ThoiGian ngay_mai()
        {
            ThoiGian ketQua = new ThoiGian();

            // tạo mảng
            // chứa tổng số ngày trong 1 tháng
            // của từng tháng
            // từ tháng 1 đến tháng 12
            int[] arr = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

            // kiểm tra năm nhuận
            if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))
            {
                arr[1] = 29;
            }

            if (ngay == 31 && thang == 12)
            {
                ketQua.ngay = 1;
                ketQua.thang = 1;
                ketQua.nam = nam + 1;
            }
            else if (ngay == arr[thang - 1] && thang != 12)
            {
                ketQua.ngay = 1;
                ketQua.thang = thang + 1;
                ketQua.nam = nam;
            }
            else if (ngay != arr[thang - 1])
            {
                ketQua.ngay = ngay + 1;
                ketQua.thang = thang;
                ketQua.nam = nam;
            }

            return ketQua;
        }

        // hàm trả về giây tiếp theo
        public ThoiGian giay_TiepTheo()
        {
            ThoiGian ketQua = new ThoiGian();

            if (gio == 23 && phut == 59 && giay == 59)
            {
                // gọi thêm cái hàm in ra ngày mai
                ketQua = this.ngay_mai();

                ketQua.gio = 0;
                ketQua.phut = 0;
                ketQua.giay = 0;
            }
            else if (gio != 23 && phut == 59 && giay == 59)
            {
                ketQua.gio = gio + 1;
                ketQua.phut = 0;
                ketQua.giay = 0;
            }
            else if (phut != 59 && giay == 59)
            {
                ketQua.gio = gio;
                ketQua.phut = phut + 1;
                ketQua.giay = 0;
            }
            else if (giay != 59)
            {
                ketQua.gio = gio;
                ketQua.phut = phut;
                ketQua.giay = giay + 1;
            }

            return ketQua;
        }

        // nạp chồng toán tử +
        // dùng để cộng giây
        // cái tham số n là giây nhé
        public static ThoiGian operator +(ThoiGian dt, long n)
        {
            ThoiGian ketQua = dt;

            if (n == 0)
            {
                return ketQua;
            }
            
            for (long i = 1; i <= n; i++)
            {
                ketQua = ketQua.giay_TiepTheo();
            }

            return ketQua;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng
            ThoiGian dt1 = new ThoiGian();
            ThoiGian dt2 = new ThoiGian(9, 12, 2023, 22, 19);
            ThoiGian dt3 = new ThoiGian(31, 1, 2004, 19, 0, 59);


            // hiển thị ra màn hình
            Console.WriteLine("-------------------- HIEN THI DU LIEU --------------------");
            Console.WriteLine(dt1.ToString());
            Console.WriteLine(dt2.ToString("dd/MM/yyyy hh:mm"));
            Console.WriteLine(dt3.ToString("dd/MM/yyyy"));


            // in ra giây tiếp theo
            Console.WriteLine("\n\n------------------ IN RA GIAY TIEP THEO ------------------");
            ThoiGian dt4 = new ThoiGian(31, 12, 2000, 23, 59, 59);
            Console.WriteLine($"Ban dau: {dt4.ToString()}\t\tLuc sau: {dt4.giay_TiepTheo().ToString()}\n");

            ThoiGian dt5 = new ThoiGian(1, 1, 1, 18, 59, 59);
            Console.WriteLine($"Ban dau: {dt5.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt5.giay_TiepTheo().ToString("hh:mm:ss")}");

            ThoiGian dt6 = new ThoiGian(1, 1, 1, 9, 50, 59);
            Console.WriteLine($"Ban dau: {dt6.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt6.giay_TiepTheo().ToString("hh:mm:ss")}");

            ThoiGian dt7 = new ThoiGian(1, 1, 1, 6, 0, 0);
            Console.WriteLine($"Ban dau: {dt7.ToString("hh:mm:ss")}\t\t\tLuc sau: {dt7.giay_TiepTheo().ToString("hh:mm:ss")}");


            // in ra ngày mai
            Console.WriteLine("\n\n--------------------- IN RA NGAY MAI ---------------------");
            ThoiGian dt8 = new ThoiGian(31, 12, 2023);
            Console.WriteLine($"Ban dau: {dt8.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt8.ngay_mai().ToString("dd/MM/yyyy")}");

            ThoiGian dt9 = new ThoiGian(28, 2, 1999);
            Console.WriteLine($"Ban dau: {dt9.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt9.ngay_mai().ToString("dd/MM/yyyy")}");

            ThoiGian dt10 = new ThoiGian(28, 2, 2000);
            Console.WriteLine($"Ban dau: {dt10.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt10.ngay_mai().ToString("dd/MM/yyyy")}");

            ThoiGian dt11 = new ThoiGian(3, 3, 2003);
            Console.WriteLine($"Ban dau: {dt11.ToString("dd/MM/yyyy")}\t\tLuc sau: {dt11.ngay_mai().ToString("dd/MM/yyyy")}");


            // nạp chồng toán tử +
            Console.WriteLine("\n\n------------------- NAP CHONG TOAN TU + -------------------");
            ThoiGian dt12 = new ThoiGian(1, 1, 2000, 0, 0, 0);
            ThoiGian tong1 = dt12 + 86400;
            Console.WriteLine($"{dt12.ToString("dd/MM/yyyy hh:mm:ss")}    +    {"86400 (giay)", -15} =    {tong1.ToString("dd/MM/yyyy hh:mm:ss")}");

            ThoiGian dt13 = new ThoiGian(22, 9, 2021, 0, 0, 0);
            ThoiGian tong2 = dt13 + 0;
            Console.WriteLine($"{dt13.ToString("dd/MM/yyyy hh:mm:ss")}    +    {"0 (giay)", -15} =    {tong2.ToString("dd/MM/yyyy hh:mm:ss")}");
        }
    }
}