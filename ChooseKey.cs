namespace APIRequest
{
	class Key
	{
		public string value;
		public void setValue(string req)
		{
			string result = (req == "public key") ? "4a4a79f8b83a4125b46222602200606" : req;
			this.value = result;
		}
	}
}