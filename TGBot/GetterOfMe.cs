namespace TGBot {

	public class GetMeInfo {
		public bool ok { get; set; }
		public GetMeResult result { get; set; }
	}

	public class GetMeResult {
		public int id { get; set; }
		public bool is_bot { get; set; }
		public string first_name { get; set; }
		public string username { get; set; }
	}

}
