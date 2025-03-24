using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <=100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount =req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.Description = "Para çekme işlemi onaylandı, Tutar: " + req.Amount;
                customerProcess.EmployeeName = "Veznedar: Deneme Denemeoğlu";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar: Deneme Denemeoğlu";
                customerProcess.Description = "Para çekme işlemi onaylanamadı çünkü; tutar veznedarın ödeyebileceği tutardan daha fazladır.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
