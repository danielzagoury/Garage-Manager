using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ClientDetails
    {
        public enum eVehicleCondition
        {
            InRepair,
            Repaired,
            Paid
        }
        public string m_ClientName { get; set; }
        public string m_ClientPhone { get; set; }
        public eVehicleCondition  m_Condition { get; set; }
        public ClientDetails(string i_ClientName, string i_ClientPhone, eVehicleCondition i_Condition)
        {
            m_ClientName=i_ClientName;
            m_ClientPhone=i_ClientPhone;
            m_Condition = i_Condition;
        }
        public void ChangeCondition(eVehicleCondition i_Condition)
        {
            m_Condition = i_Condition;
        }
        public string GetConditionOfTheCar()
        {
            return m_Condition.ToString();
        }
    }
}
