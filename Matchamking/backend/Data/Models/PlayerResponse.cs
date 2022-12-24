using System;
using System.Collections.Generic;

namespace backend.Data.Models
{	
	public class PlayerResponse<T>
	{
		private string stsCod;
		private string stsMsg;
		private List<T> bodyResponseList;

		public string StsCod { get { return stsCod; } set { stsCod = value; } }
		public string StsMsg { get { return stsMsg; } set { stsCod = value; } }
		public string BodyResponseList { get; set; }

		public PlayerResponse()
		{
		}
		
		public PlayerResponse(string stsCod, string stsMsg, List<T> bodyResponseList)
		{
			this.stsCod = stsCod;
			this.stsMsg = stsMsg;
			this.bodyResponseList = bodyResponseList;
		}
	}
}
