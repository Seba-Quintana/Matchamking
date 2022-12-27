using System;
using System.Collections.Generic;

namespace backend.Data.Models
{
	public class JugadorResponse<T>
	{
		public string StsCod { get; set; }
		public string StsMsg { get; set; }
		public List<T> BodyResponseList { get; set; }

		public JugadorResponse()
		{
			BodyResponseList = new List<T>();
		}
		
		public JugadorResponse(string stsCod, string stsMsg, List<T> bodyResponseList)
		{
			this.StsCod = stsCod;
			this.StsMsg = stsMsg;
			this.BodyResponseList = bodyResponseList;
		}
	}
}
