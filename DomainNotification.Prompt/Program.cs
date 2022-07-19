using DomainNotification.Application.Services;
using DomainNotification.Prompt.Dto;
using DomainNotification.Prompt.Utils;
using System;
using System.Collections.Generic;

namespace DomainNotification.Prompt
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                dynamic referenceDate, numberTrades, trade, aux, index, isPoliticallyExposed = false;
                const int INITIAL = 1;
                int count = 1;

                do
                {
                    if (count == INITIAL)
                    {
                        Console.WriteLine("\nType the reference date:");
                        referenceDate = Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nIncorrect date, retype the reference date (mm/dd/yyyy):");
                        Console.ForegroundColor = ConsoleColor.White;
                        referenceDate = Console.ReadLine();
                    }
                    count++;
                } while (ValidFields.Date(referenceDate));

                count = INITIAL;

                do
                {
                    if (count == INITIAL)
                    {
                        Console.WriteLine("\nType the number of trades in the portfolio:");
                        numberTrades = Console.ReadLine();
                        count++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nIncorret number, retype the number of trades in the portfolio:");
                        Console.ForegroundColor = ConsoleColor.White;
                        numberTrades = Console.ReadLine();
                    }
                    count++;
                } while (ValidFields.Number(numberTrades));

                var trades = new List<string>();

                count = INITIAL;
                index = INITIAL;

                while (Convert.ToInt16(numberTrades) >= index)
                {
                    do
                    {
                        if (count == INITIAL)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"\nType the Trade - {index}");
                            trade = Console.ReadLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\nIncorrect value. Retype the Trade - {index}:");
                            Console.ForegroundColor = ConsoleColor.White;
                            trade = Console.ReadLine();
                        }
                        aux = trade.Substring(0).Split(' ');
                        count++;

                    } while (ValidFields.Number(aux[0])
                             || ValidFields.Sector(aux[1])
                             || ValidFields.Date(aux[2]));

                    trades.Add(trade);
                    index++;
                    count = INITIAL;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAlerts\n");

                foreach (var t in trades)
                {
                    string text = t.Trim();
                    string[] strTrade = text.Substring(0).Split(' ');
                    var tradeDto = new TradeDto(Guid.NewGuid(), FormatDate.Convert(referenceDate), Convert.ToInt16(numberTrades), Convert.ToDouble(strTrade[0]), Convert.ToString(strTrade[1]), FormatDate.Convert(strTrade[2]), isPoliticallyExposed);
                    var tradeService = new TradeService(tradeDto.TradeId, tradeDto.ReferenceDate, tradeDto.NumberTrades, tradeDto.Value, tradeDto.ClientSector, tradeDto.NextPaymentDate, tradeDto.IsPoliticallyExposed);

                    Submit(tradeService, tradeDto);
                }
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Submit(TradeService tradeService, TradeDto tradeDto)
        {
            tradeService.SaveTrade(tradeDto.TradeId, tradeDto.ReferenceDate, tradeDto.NumberTrades, tradeDto.Value, tradeDto.ClientSector, tradeDto.NextPaymentDate, tradeDto.IsPoliticallyExposed);

            if (tradeService.HasNotifications)
                ShowNotifications(tradeService);
        }

        private static void ShowNotifications(Service tradeService)
        {
            if (!tradeService.HasNotifications) return;

            if (tradeService.HasAlerts)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (var alert in tradeService.Alerts())
                {
                    Console.WriteLine(alert.ToString());
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Registration contains no risks.");
            }
        }
    }
}