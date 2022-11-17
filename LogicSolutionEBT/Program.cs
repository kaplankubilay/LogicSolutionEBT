using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicSolutionEBT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string roadMap = "LMLMLMLMM";
                string locationStart = "1 2 N";

                LocationModel location = FindLocation(locationStart, roadMap);

                Console.WriteLine($"{location.X} {location.Y} {location.Route}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                throw new Exception("MainMetod", ex.InnerException);
            }
            finally{
                Console.ReadLine();
            }

        }

        private static string RemoveSpace(string input)
        {
            try
            {
                return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static LocationModel GetLocation(string locationStart)
        {
            try
            {
                locationStart = RemoveSpace(locationStart);
                LocationModel location = new LocationModel()
                {
                    X = Convert.ToInt32(locationStart.Substring(0, 1)),
                    Y = Convert.ToInt32(locationStart.Substring(1, 1)),
                    Route = locationStart.Substring(2, 1)
                };

                return location;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static LocationModel FindLocation(string locationStart, string roadMap)
        {
            try
            {
                LocationModel location = GetLocation(locationStart);
                var stepCount = roadMap.Length;
                int startRoute = FindRoute(location.Route);

                for (int i = 0; i < stepCount; i++)
                {
                    var step = roadMap[i];

                    if (step == 'L')
                    {
                        startRoute -= 1;
                        if (startRoute == -1)
                        {
                            startRoute = Routes.W;
                        }
                        continue;
                    }

                    if (step == 'R')
                    {
                        startRoute += 1;
                        if (startRoute == 4)
                        {
                            startRoute = Routes.N;
                        }
                        continue;
                    }

                    if (step == 'M')
                    {
                        if (startRoute == Routes.N)
                            location.Y += 1;

                        if (startRoute == Routes.E)
                            location.X += 1;

                        if (startRoute == Routes.S)
                            location.Y -= 1;

                        if (startRoute == Routes.W)
                            location.X -= 1;
                    }
                }
                return location;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int FindRoute(string startRoute)
        {
            try
            {
                if (startRoute == "N")
                    return Routes.N;

                else if (startRoute == "E")
                    return Routes.E;

                else if (startRoute == "S")
                    return Routes.S;

                else
                    return Routes.W;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

