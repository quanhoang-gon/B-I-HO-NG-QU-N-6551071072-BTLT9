using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cau_3.Helpers
{
    public static class Strings
    {
        public static string CurrentCulture { get; private set; } = "vi-VN";
        public static CultureInfo CurrentCultureInfo { get; private set; } = new CultureInfo("vi-VN");

        public static void SetCulture(string culture)
        {
            CurrentCulture = (culture == "en-US") ? "en-US" : "vi-VN";
            CurrentCultureInfo = new CultureInfo(CurrentCulture);
        }

        private static readonly Dictionary<string, Dictionary<string, string>> _map = new()
        {
            ["vi-VN"] = new()
            {
                ["AppTitle"] = "Kế hoạch dã ngoại & Dự báo thời tiết",
                ["SubTitle"] = "Ghi chép kế hoạch chuyến đi | Tự động tra cứu dự báo thời tiết Open-Meteo",
                ["Language"] = "Ngôn ngữ:",
                ["Vietnamese"] = "Tiếng Việt",
                ["English"] = "English",
                ["TripInfoGroup"] = "Thông tin chuyến đi",
                ["TripID"] = "Mã chuyến:",
                ["TripName"] = "Tên chuyến:*",
                ["Location"] = "Địa điểm:*",
                ["DepartDate"] = "Ngày đi:*",
                ["PeopleCount"] = "Số người:*",
                ["Budget"] = "Ngân sách:*",
                ["Vehicle"] = "Phương tiện:*",
                ["Completed"] = "Đã hoàn thành",
                ["Note"] = "Ghi chú:",
                ["BtnAdd"] = "Thêm",
                ["BtnEdit"] = "Sửa",
                ["BtnDelete"] = "Xóa",
                ["BtnReset"] = "Làm mới",
                ["BtnCheckWeather"] = "⛅ Xem thời tiết",
                ["FilterGroup"] = "Tìm kiếm & Lọc dữ liệu",
                ["SearchPlaceholder"] = "Nhập tên chuyến hoặc địa điểm...",
                ["OnlyIncomplete"] = "Chỉ hiện chuyến chưa hoàn thành",
                ["FilterByDate"] = "Khoảng ngày đi:",
                ["To"] = "đến",
                ["BtnClearFilter"] = "Bỏ lọc",
                ["TripListGroup"] = "Danh sách kế hoạch dã ngoại",
                ["ColID"] = "Mã",
                ["ColTripName"] = "Tên chuyến đi",
                ["ColLocation"] = "Địa điểm",
                ["ColDepartDate"] = "Ngày đi",
                ["ColPeople"] = "Số người",
                ["ColBudget"] = "Ngân sách",
                ["ColVehicle"] = "Phương tiện",
                ["ColStatus"] = "Trạng thái",
                ["ColNote"] = "Ghi chú",
                ["WeatherGroup"] = "Dự báo thời tiết Open-Meteo",
                ["WeatherReady"] = "Chọn chuyến đi và bấm 'Xem thời tiết' để tra cứu",
                ["WeatherLoading"] = "Đang tra cứu dữ liệu thời tiết...",
                ["WeatherTempRange"] = "Nhiệt độ:",
                ["WeatherRainProb"] = "Xác suất mưa:",
                ["RainWarning"] = "⚠️ Nên mang áo mưa hoặc cân nhắc dời lịch!",
                ["NoForecastData"] = "Chưa có dữ liệu dự báo (chỉ hỗ trợ tối đa 16 ngày tới).",
                ["LocationNotFound"] = "Không tìm thấy tọa độ địa điểm này. Vui lòng kiểm tra lại tên địa danh (thử viết không dấu).",
                ["NetworkError"] = "Không thể kết nối đến máy chủ thời tiết. Vui lòng kiểm tra kết nối mạng.",
                ["VehicleMotorbike"] = "Xe máy",
                ["VehicleCar"] = "Ô tô",
                ["VehicleCoach"] = "Xe khách",
                ["VehicleTrain"] = "Tàu hỏa",
                ["StatusCompleted"] = "Đã hoàn thành",
                ["StatusPlanning"] = "Đang lên kế hoạch",
                ["MsgTripNameEmpty"] = "Tên chuyến đi không được để trống!",
                ["MsgLocationEmpty"] = "Địa điểm dã ngoại không được để trống!",
                ["MsgDepartDatePast"] = "Ngày đi khi thêm mới không được nhỏ hơn ngày hôm nay!",
                ["MsgPeopleMin"] = "Số người tham gia phải từ 1 người trở lên!",
                ["MsgBudgetMin"] = "Ngân sách chuyến đi phải lớn hơn hoặc bằng 0!",
                ["MsgConfirmDelete"] = "Bạn có chắc chắn muốn xóa chuyến đi [{0}] - \"{1}\" không?",
                ["MsgAddSuccess"] = "Thêm chuyến đi mới thành công!",
                ["MsgEditSuccess"] = "Cập nhật chuyến đi thành công!",
                ["MsgDeleteSuccess"] = "Xóa chuyến đi thành công!",
                ["MsgPleaseSelectRow"] = "Vui lòng chọn một dòng chuyến đi trên bảng!",
                ["SummaryLabel"] = "Tổng cộng: {0} chuyến | Tổng ngân sách: {1}",
                ["WeatherClearSky"] = "Trời quang, nắng đẹp",
                ["WeatherPartlyCloudy"] = "Có mây rải rác / nhiều mây",
                ["WeatherFog"] = "Có sương mù",
                ["WeatherRain"] = "Có mưa / mưa rào",
                ["WeatherThunderstorm"] = "Có dông lốc, sấm sét"
            },
            ["en-US"] = new()
            {
                ["AppTitle"] = "Picnic Trip Planner & Weather Forecast",
                ["SubTitle"] = "Record picnic trips | Real-time Open-Meteo weather forecast",
                ["Language"] = "Language:",
                ["Vietnamese"] = "Tiếng Việt",
                ["English"] = "English",
                ["TripInfoGroup"] = "Trip Information",
                ["TripID"] = "Trip ID:",
                ["TripName"] = "Trip Name:*",
                ["Location"] = "Location:*",
                ["DepartDate"] = "Departure:*",
                ["PeopleCount"] = "People:*",
                ["Budget"] = "Budget:*",
                ["Vehicle"] = "Transport:*",
                ["Completed"] = "Completed",
                ["Note"] = "Note:",
                ["BtnAdd"] = "Add",
                ["BtnEdit"] = "Edit",
                ["BtnDelete"] = "Delete",
                ["BtnReset"] = "Reset",
                ["BtnCheckWeather"] = "⛅ View Weather",
                ["FilterGroup"] = "Search & Filters",
                ["SearchPlaceholder"] = "Search trip name or location...",
                ["OnlyIncomplete"] = "Show incomplete trips only",
                ["FilterByDate"] = "Date range:",
                ["To"] = "to",
                ["BtnClearFilter"] = "Clear filter",
                ["TripListGroup"] = "Planned Picnic Trips",
                ["ColID"] = "ID",
                ["ColTripName"] = "Trip Name",
                ["ColLocation"] = "Location",
                ["ColDepartDate"] = "Departure Date",
                ["ColPeople"] = "People",
                ["ColBudget"] = "Budget",
                ["ColVehicle"] = "Transport",
                ["ColStatus"] = "Status",
                ["ColNote"] = "Note",
                ["WeatherGroup"] = "Open-Meteo Weather Forecast",
                ["WeatherReady"] = "Select a trip and click 'View Weather'",
                ["WeatherLoading"] = "Fetching weather forecast data...",
                ["WeatherTempRange"] = "Temperature:",
                ["WeatherRainProb"] = "Rain Probability:",
                ["RainWarning"] = "⚠️ Bring a raincoat or consider rescheduling!",
                ["NoForecastData"] = "No forecast data available (max 16 days ahead).",
                ["LocationNotFound"] = "Location not found. Please verify the place name.",
                ["NetworkError"] = "Cannot connect to weather service. Please check network connection.",
                ["VehicleMotorbike"] = "Motorbike",
                ["VehicleCar"] = "Car",
                ["VehicleCoach"] = "Coach",
                ["VehicleTrain"] = "Train",
                ["StatusCompleted"] = "Completed",
                ["StatusPlanning"] = "In planning",
                ["MsgTripNameEmpty"] = "Trip name cannot be empty!",
                ["MsgLocationEmpty"] = "Location cannot be empty!",
                ["MsgDepartDatePast"] = "Departure date cannot be in the past for new trips!",
                ["MsgPeopleMin"] = "Number of people must be at least 1!",
                ["MsgBudgetMin"] = "Budget must be greater than or equal to 0!",
                ["MsgConfirmDelete"] = "Are you sure you want to delete trip [{0}] - \"{1}\"?",
                ["MsgAddSuccess"] = "New trip added successfully!",
                ["MsgEditSuccess"] = "Trip updated successfully!",
                ["MsgDeleteSuccess"] = "Trip deleted successfully!",
                ["MsgPleaseSelectRow"] = "Please select a trip row from the table!",
                ["SummaryLabel"] = "Total: {0} trips | Total budget: {1}",
                ["WeatherClearSky"] = "Clear sky, sunny",
                ["WeatherPartlyCloudy"] = "Partly cloudy / Overcast",
                ["WeatherFog"] = "Foggy",
                ["WeatherRain"] = "Rain / Showers",
                ["WeatherThunderstorm"] = "Thunderstorm with rain"
            }
        };

        public static string Get(string key)
        {
            if (_map.TryGetValue(CurrentCulture, out var dict) && dict.TryGetValue(key, out var val))
            {
                return val;
            }
            if (_map["vi-VN"].TryGetValue(key, out var defaultVal))
            {
                return defaultVal;
            }
            return key;
        }

        public static string Format(string key, params object[] args)
        {
            string raw = Get(key);
            try
            {
                return string.Format(CurrentCultureInfo, raw, args);
            }
            catch
            {
                return raw;
            }
        }
    }
}
