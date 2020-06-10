namespace APIRequest
{
	class Key
	{
		public string value;
		public void setValue(string req)
		{
			string result = (req == "public key") ? "35458aadabe8465c98501432201006" : req;
			this.value = result;
		}
	}
}