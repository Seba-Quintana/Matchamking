﻿using System;
using System.Collections.Generic;

namespace backend.Data.Models
{
	public class PlayerResponse<T>
	{
		public string StsMsg { get; set; }
		public string StsCod { get; set; }
		public List<T> BodyResponseList { get; set; }

		public PlayerResponse()
		{
		}
		
		public PlayerResponse(string stsCod, string stsMsg, List<T> bodyResponseList)
		{
			this.StsCod = stsCod;
			this.StsMsg = stsMsg;
			this.BodyResponseList = bodyResponseList;
		}
	}
}
