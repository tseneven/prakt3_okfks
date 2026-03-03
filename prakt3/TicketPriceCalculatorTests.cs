using CinemaTicketSystem;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace prakt3
{
    public class TicketPriceCalculatorTests
    {
        [Fact]
        public void regularTicketWithoutDiscountsTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 26;
            DayOfWeek day = DayOfWeek.Sunday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(300, calculator.CalculatePrice(ticketRequest));
        }

        [Fact]
        public void childrensTicketsTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 10;
            DayOfWeek day = DayOfWeek.Sunday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 180;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }

        [Fact]
        public void pensionersTicketsTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 67;
            DayOfWeek day = DayOfWeek.Sunday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 150;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }
        [Fact]
        public void studentsTicketsTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = true;
            bool isVip = false;
            int age = 20;
            DayOfWeek day = DayOfWeek.Sunday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 240;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }

        [Fact]
        public void morningDiscountTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 26;
            DayOfWeek day = DayOfWeek.Sunday;
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            int result = 255;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }
        [Fact]
        public void discountOnWednesdayTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 26;
            DayOfWeek day = DayOfWeek.Wednesday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 210;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }
        [Fact]
        public void VIPMarkupWithoutDiscountsTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = true;
            int age = 26;
            DayOfWeek day = DayOfWeek.Monday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 600;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }

        [Fact]
        public void VIPMarkupWithDiscountsTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = true;
            int age = 26;
            DayOfWeek day = DayOfWeek.Wednesday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 420;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }
        [Fact]
        public void severalDiscountsAtOnceTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = true;
            bool isVip = false;
            int age = 26;
            DayOfWeek day = DayOfWeek.Wednesday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 210;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }
        [Fact]
        public void maximumDiscountTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = true;
            bool isVip = false;
            int age = 5;
            DayOfWeek day = DayOfWeek.Wednesday;
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            int result = 0;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }

        [Fact]
        public void ThresholdValue_5_6_AgeTest_Age_5()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 5;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 0;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValue_5_6_AgeTest_Age_6()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 6;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 180;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValue_17_18_AgeTest_Age_17()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 17;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 180;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValue_17_18_AgeTest_Age_18()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 18;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 300;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValue_25_26_AgeTest_Age_25()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 25;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 300;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValu25_26_AgeTest_Age_26()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 26;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 300;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValue64_65_AgeTest_Age_64()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 64;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 300;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void ThresholdValu64_65_AgeTest_Age_65()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 65;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 150;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }

        [Fact]
        public void ThresholdValueMinimumPermissibleAgeTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 0;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 0;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));

        }

        [Fact]
        public void ThresholdValueMaximumPermissibleAgeTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 120;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 150;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Equal(result, calculator.CalculatePrice(ticketRequest));
        }

        [Fact]
        public void TicketRequestNullTest()
        {
            TicketRequest ticketRequest = null;
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            Assert.Throws<ArgumentNullException>(() => calculator.CalculatePrice(ticketRequest));
        }
        [Fact]
        public void IncorrectMinAgeTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = -1;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 0;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculatePrice(ticketRequest));

        }

        [Fact]
        public void IncorrectMaxAgeTest()
        {
            TicketRequest ticketRequest = new TicketRequest();
            TicketPriceCalculator calculator = new TicketPriceCalculator();

            bool isStudent = false;
            bool isVip = false;
            int age = 121;
            DayOfWeek day = DayOfWeek.Friday;
            TimeSpan timeSpan = TimeSpan.FromHours(13);
            int result = 0;

            ticketRequest.IsStudent = isStudent;
            ticketRequest.IsVip = isVip;
            ticketRequest.Day = day;
            ticketRequest.Age = age;
            ticketRequest.SessionTime = timeSpan;

            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculatePrice(ticketRequest));

        }

    }
}