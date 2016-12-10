namespace CalcMaze
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class InputParser
    {
        public static Puzzle Parse(string input)
        {
            var puzzle = new Puzzle();
            var matchEx = new Regex(@"(?<CalcType>[+\-*/])?(?<CalcVal>\d+)");

            var map = new List<List<Location>>();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            puzzle.Goal = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] lineVals = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var row = new List<Location>();
                for (int j = 0; j < lineVals.Length; j++)
                {
                    var loc = new Location(j, i - 1);
                    var result = matchEx.Match(lineVals[j]);
                    loc.CalcValue = int.Parse(result.Groups["CalcVal"].Value);
                    loc.CalcType = CalcType.None;
                    if (result.Groups["CalcType"] != null)
                    {
                        string ct = result.Groups["CalcType"].Value;
                        switch (ct)
                        {
                            case "+":
                                loc.CalcType = CalcType.Plus;
                                break;
                            case "*":
                                loc.CalcType = CalcType.Mult;
                                break;
                            case "-":
                                loc.CalcType = CalcType.Minus;
                                break;
                        }
                    }

                    row.Add(loc);
                }

                map.Add(row);
            }

            puzzle.Map = map;
            return puzzle;
        }
    }
}