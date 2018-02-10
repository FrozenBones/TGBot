using System;

namespace TGBot {
	public class GetUpdatesInfo {
		public bool ok { get; set; }
		public GUResult[] result { get; set; }
	}

	public class GUResult {
		public int update_id { get; set; }
		public GUMessage message { get; set; }
	}

	public class GUMessage {
		public int message_id { get; set; }
		public GUFrom from { get; set; }
		public GUChat chat { get; set; }
		public int date { get; set; }
		public string text { get; set; }
	}

	public class GUFrom {
		public int id { get; set; }
		public bool is_bot { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string username { get; set; }
		public string language_code { get; set; }
	}

	public class GUChat {
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string username { get; set; }
		public string type { get; set; }
	}
	}