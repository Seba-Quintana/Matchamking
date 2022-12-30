using System;
using System.Collections.Generic;

namespace backend.Data.Models
{
	public class Response<T>
	{
		public string StsCod { get; set; }
		public string StsMsg { get; set; }
		public List<T> BodyResponseList { get; set; }

		public Response()
		{
			BodyResponseList = new List<T>();
		}
		
		public Response(string stsCod, string stsMsg, List<T> bodyResponseList)
		{
			this.StsCod = stsCod;
			this.StsMsg = stsMsg;
			this.BodyResponseList = bodyResponseList;
		}
	}
}
