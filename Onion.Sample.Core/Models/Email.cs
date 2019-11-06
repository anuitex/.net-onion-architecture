namespace Onion.Sample.Core.Models
{
	public class Email
	{
		public string FromMail { get; private set; }
		public string ToMail { get; private set; }
		public string Subject { get; private set; }
		public string Body { get; private set; }

		public Email(string toMail, string subject, string body, string fromMail = null)
		{
			FromMail = fromMail;
			ToMail = toMail;
			Subject = subject;
			Body = body;
		}
	}
}
