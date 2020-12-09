using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yogaAshram.Models;
using yogaAshram.Models.ModelViews;

namespace yogaAshram.Services
{
    public class PaymentsService
    {
        private readonly YogaAshramContext _db;

        public PaymentsService(YogaAshramContext db)
        {
            _db = db;
        }
        public async Task<bool> EditPayment(PaymentEditModelView model)
        {
            if (model.CashSum is null)
                model.CashSum = 0;
            if (model.CardSum is null)
                model.CardSum = 0;
            int sum = (int)model.CashSum + (int)model.CardSum;
            Payment payment = await _db.Payments.FindAsync(model.PaymentId);
            int oldSum = payment.CashSum + payment.CardSum;
            Client client = payment.ClientsMembership.Client;
            if (payment is null)
                return false;
            payment.Comment = model.Comment;
            payment.CashSum = (int)model.CashSum;
            payment.CardSum = (int)model.CardSum;
            payment.LastUpdate = DateTime.Now;
            if (payment.Type == PaymentType.Pay)
                client.Balance += payment.Debts;
            else
                client.Balance -= oldSum;
            payment.Type = model.Type;
            int balance = client.Balance;
            if (balance < 0)
                balance = 0;
            int debts = payment.ClientsMembership.Membership.Price - sum - balance;
            SetParams(ref payment, ref client, debts, payment.Type, sum);
            _db.Entry(client).State = EntityState.Modified;
            _db.Entry(payment).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<string> CreatePayment(PaymentCreateModelView model, ClientsMembership clientsMembership, Client client, long employeeId)
        {
            model.BranchId = client.Group.BranchId;
            int sum = model.CashSum + model.CardSum;
            if (sum == 0 || sum < 0)
                return "negativeOrZero";
            
            if (client.Balance < 0 && model.Type == PaymentType.Pay)
                return "false";
            if (client.Membership is null && model.Type == PaymentType.Pay)
                return "false";
            int balance = client.Balance;
            if (balance < 0)
                balance = 0;
            Membership membership = client.Membership;
            int debts = membership.Price - sum - balance;
            if (clientsMembership is null)
                return "false";
            Payment payment = new Payment()
            {
                Comment = model.Comment,
                ClientsMembershipId = clientsMembership.Id,
                CreatorId = employeeId,
                CashSum = (int)model.CashSum,
                CardSum = (int)model.CardSum,
                Type = model.Type,
                BranchId = model.BranchId
            };
            CurrentSum currentSum = _db.CurrentSums.FirstOrDefault(p => p.BranchId == model.BranchId);
           
            currentSum.CashSum += model.CashSum;
            currentSum.CreditSum += model.CardSum;
            _db.Entry(currentSum).State = EntityState.Modified;
         
            SetParams(ref payment, ref client, debts, model.Type, sum);
            _db.Entry(client).State = EntityState.Modified;
            _db.Entry(payment).State = EntityState.Added; 
        
            await _db.SaveChangesAsync();
            return "success";
        }
        public async Task<bool> PayForMembership(PaymentCreateModelView model, ClientsMembership clientsMembership, Client client, long employeeId)
        {
            int sum = (int)model.CashSum + (int)model.CardSum;
            int balance = client.Balance;
            if (balance < 0)
                balance = 0;
            Membership membership = client.Membership;
            int debts = membership.Price - sum - balance;
            Payment payment = new Payment()
            {
                Comment = model.Comment,
                ClientsMembershipId = clientsMembership.Id,
                CreatorId = employeeId,
                CashSum = (int)model.CashSum,
                CardSum = (int)model.CardSum,
                Type = model.Type,
                BranchId = model.BranchId
            };
            CurrentSum currentSum = _db.CurrentSums.FirstOrDefault(p => p.BranchId == model.BranchId);
           
            currentSum.CashSum += model.CashSum;
            currentSum.CreditSum += model.CardSum;
            _db.Entry(currentSum).State = EntityState.Modified;
         
            SetParams(ref payment, ref client, debts, model.Type, sum);
            _db.Entry(client).State = EntityState.Modified;
            _db.Entry(payment).State = EntityState.Added; 
        
            await _db.SaveChangesAsync();
            return true;
        }
        private void SetParams(ref Payment payment, ref Client client, int debts, PaymentType type, int amount)
        {
            if (debts > 0 && type == PaymentType.Pay)
            {
                client.Paid = Paid.Есть_долг;
                client.Color = "dark";
                client.Balance -= debts;
                payment.Debts = -client.Balance;
            }
            else
            {
                if (type == PaymentType.Pay)
                {
                    client.Paid = Paid.Оплачено;
                    client.Color = "";
                    client.Balance -= debts;
                    payment.Debts = 0;
                }
                else
                {
                    client.Balance += amount;
                    if (client.Balance >= 0)
                    {
                        client.Paid = Paid.Оплачено;
                        client.Color = "";
                        payment.Debts = 0;
                    }
                    else
                        payment.Debts = -client.Balance;
                }
            }
        }
        
    }
}
