using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TGBot {
	public class TelegramBot {
		public string Token { get; private set; }
		public string Link { get; private set; }

		public TelegramBot(string token) {
			this.Token = token;
			Link = String.Format("https://api.telegram.org/bot{0}/", Token);
		}
		//Методы Bot API
		//Надо добавить аргумент, ограничивающий поступление старых сообщений из списка
		public GetUpdatesInfo GetUpdates() {
			string data = GetData("getUpdates");
			return JsonConvert.DeserializeObject<GetUpdatesInfo>(data);
		}
		public MessageSender SendMessage(int chatId, string text) {
			string data = GetData(String.Format("sendMessage?chat_id={0}&text={1}", chatId, text));
			return JsonConvert.DeserializeObject<MessageSender>(data);
		}
		public GetMeInfo GetMe() {
			string data = GetData("getMe");
			return JsonConvert.DeserializeObject<GetMeInfo>(data);
		}
		//Вспомогательные методы
		private string GetData(string query) {
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Link + query);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
				return reader.ReadToEnd();
			}
		}
		/*
		 Нужно реализовать хранение полученных сообщений и при получении нового добавлять его в список.
		 1. При старте программы будет создаваться массив, собирающий данные о ранних сообщениях из хранилища.
		 2. В конце работы программы будет происходить выгрузка массива с прошлыми и новыми данными в хранилище.
		 3. Возможна реализация отдельного класса для этого массива, для хранилища и т.д.
		 4. Хранилище, возможно, будет представлять собой базу данных SQLite3, JSON, либо XML.
		 5. Скорее всего, данные будут храниться в виде зашифрованного кода JSON/XML
		 в файле специального расширения. Будут храниться сериализованные массивы-объекты класса GUResult.

			 */
		public void Work() {
			while (true) {
				GetUpdatesInfo jsData = GetUpdates();
				GUResult[] respones = jsData.result;
				// сообщения, отправленные боту, должны прослушиваться, а затем обрабатываться
				foreach (GUResult respone in respones) {
					/*
						ЕСЛИ сообщениеНеДобавленоВХранилище ТОГДА
							//сообщения считываются в порядке возрастания новизны, т.е. начиная с самых старых
							ФУНК {добавить сообщение в хранилище (массив) и вывести на экран}
							//старые сообщения должны отсеиваться с использованием даты timestamp
							//т.е. нужно не допускать в запрос данные, дата которых старше определённой,
							//а саму дату нужно хранить в хранилище
							ФУНК {инкриментировать счётчик, ограничивающий поступление старых сообщений}
						ИНАЧЕ
							
						КОНЕЦ
					*/
				}
			}
		}
	}
}
/*
 
	1. Сначала нужно изучить то, как создать скролл-бар, чтобы можно было хранить все предыдущие сообщения
	в блоке с ним.
	2. Нужно создать систему прогрузки элементов, как в вк, чтобы сильно не перегружалась система при
	присутствии всех элементов в блоке со скролл-баром.
	 
	 */