﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataAccess.Repository
{
	public interface IUnitOfWork
	{
		IBrandRepository Brand { get; }

		void update();
	}
}