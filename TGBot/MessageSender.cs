namespace TGBot {

	public class MessageSender {
		public bool ok { get; set; }
		public MSResult result { get; set; }
	}

	public class MSResult {
		public int message_id { get; set; }
		public MSFrom from { get; set; }
		public MSChat chat { get; set; }
		public int date { get; set; }
		public string text { get; set; }
	}

	public class MSFrom {
		public int id { get; set; }
		public bool is_bot { get; set; }
		public string first_name { get; set; }
		public string username { get; set; }
	}

	public class MSChat {
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string username { get; set; }
		public string type { get; set; }
	}

}
