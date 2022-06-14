using System;
using System.Collections.Generic;
using System.Text;

namespace PTSLibrary
{
	class PTSCustomerFacade : PTSSuperFacade
	{
		private DAO.CustomerDAO dao;

		public PTSCustomerFacade() : base(new DAO.CustomerDAO())
		{
			dao = (DAO.CustomerDAO)base.dao;
		}

		public Project[] GetListOfProjects(int customerId)
		{
			return (dao.GetListOfProjects(customerId)).ToArray();
		}
	}
}
