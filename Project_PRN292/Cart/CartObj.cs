using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292.Cart
{
    public class CartObj
    {
        public Dictionary<Phone, int> cart { get; set; }
        public User user { get; set; }
        public double total { get => GetTotal(); }

        public double GetTotal()
        {
            double sum = 0;
            if (cart != null)
            {
                foreach (var x in cart)
                {
                    Phone p = x.Key;
                    int quantity = x.Value;
                    sum += ((p.price * (1 - p.discount)) * quantity);
                }
            }
            return sum;
        }

        public void AddToCart(string phoneID)
        {
            if (cart == null)
            {
                cart = new Dictionary<Phone, int>();
            }
            PhoneDAO dao = new PhoneDAO();
            Phone phone = dao.GetPhone(phoneID);
            if (phone != null)
            {
                int quantity = 1;
                if (cart.ContainsKey(phone))
                {
                    quantity = cart[phone] + 1;
                    if (quantity <= phone.quantity)
                    {
                        cart[phone] = quantity;
                    }
                }
                else
                {
                    cart.Add(phone, quantity);
                }
            }
        }
        public void AddToCart(string phoneID, int value)
        {
            if (cart == null)
            {
                cart = new Dictionary<Phone, int>();
            }
            PhoneDAO dao = new PhoneDAO();
            Phone phone = dao.GetPhone(phoneID);
            if (phone != null)
            {
                int quantity = 1;
                if (cart.ContainsKey(phone))
                {
                    quantity = cart[phone] + value;
                    if (quantity <= phone.quantity)
                    {
                        cart[phone] = quantity;
                    }
                }
                else
                {
                    cart.Add(phone, quantity);
                }
            }

        }

        public void RemoveCart(string phoneID)
        {
            if (cart == null)
            {
                return;
            }
            else
            {
                PhoneDAO dao = new PhoneDAO();
                Phone phone = dao.GetPhone(phoneID);
                if (phone != null)
                {
                    if (cart.ContainsKey(phone))
                    {
                        cart.Remove(phone);
                    }
                    if (cart.Count == 0)
                    {
                        cart = null;
                    }
                }
            }

        }

        public void UpdateCart(string phoneID, int value)
        {
            if (cart == null)
            {
                cart = new Dictionary<Phone, int>();
            }
            else
            {
                PhoneDAO dao = new PhoneDAO();
                Phone phone = dao.GetPhone(phoneID);
                if (phone != null)
                {
                    if (cart.ContainsKey(phone))
                    {
                        cart[phone] = value;
                    }
                }
            }

        }

    }
}