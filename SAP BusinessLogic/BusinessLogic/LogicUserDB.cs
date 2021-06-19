using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SAP_BusinessLogic.BusinessLogic
{
    public class LogicUserDB
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        //public readonly RespositoryContext context;
        public LogicUserDB()
        {
           // context = new RespositoryContext();
        }
        // validate username and password...
        public bool ValidLogin()
        {
            var appId = ConfigurationManager.AppSettings["AppID"];
            var appKey = ConfigurationManager.AppSettings["AppKey"];
            bool isValidUser = false;
            int thisUserId = 0;
            try
            {

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return false;
        }
    }
}
