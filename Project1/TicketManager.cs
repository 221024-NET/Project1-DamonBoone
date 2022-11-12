﻿using Project1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.App
{
    public class TicketManager
    {
        TicketRepository ticketRepo;
        TicketIO ticketIO;

        public TicketManager(TicketRepository ticketRepo, TicketIO IO)
        {
            this.ticketRepo = ticketRepo;
            this.ticketIO = IO;
        }

        public void createTicket()
        {
            bool keepGoing = true;
            Console.WriteLine("Welcome to the Ticket Creator.");

            while (keepGoing)
            {
                double amount = ticketIO.getAmount();
                string description = ticketIO.getDescription();
                if(ticketRepo.createTicket(amount, description))
                {
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("That ticket already exists. Duplicates are not allowed. Please try again.");
                    continue;
                }
            }
        }
    }
}