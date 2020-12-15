using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static POS.Common.Enums;

namespace POS.Common
{
    /// <summary>
    /// Sql command text validator
    /// </summary>
    public static class CommandTextValidator
    {
        /// <summary>
        /// Validate the parameters passed from client to SQl server gets checked here
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="authorizedStatements"></param>
        //public static bool ValidateStatement(string commandText, StatementTypes authorizedStatements)
        //{
        //    bool isValid = true;

        //    try
        //    {
        //        //Construct Regular Expression To Find Text Blocks, Statement Breaks & SQL Statement Headers
        //        string regExText = "('(''|[^'])*')|(;)|(\\b(ALTER|CREATE|DELETE|DROP|EXEC(UTE){0,1}|INSERT( +INTO){0,1}|MERGE|SELECT|UPDATE|UNION( +ALL){0,1})\\b)";

        //        //Remove Authorized Options
        //        if ((authorizedStatements & StatementTypes.Batch) == StatementTypes.Batch)
        //            regExText = regExText.Replace("(;)", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Alter) == StatementTypes.Alter)
        //            regExText = regExText.Replace("ALTER", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Create) == StatementTypes.Create)
        //            regExText = regExText.Replace("CREATE", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Delete) == StatementTypes.Delete)
        //            regExText = regExText.Replace("DELETE", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Delete) == StatementTypes.Delete)
        //            regExText = regExText.Replace("DELETETREE", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Drop) == StatementTypes.Drop)
        //            regExText = regExText.Replace("DROP", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Execute) == StatementTypes.Execute)
        //            regExText = regExText.Replace("EXEC(UTE){0,1}", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Insert) == StatementTypes.Insert)
        //            regExText = regExText.Replace("INSERT( +INTO){0,1}", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Merge) == StatementTypes.Merge)
        //            regExText = regExText.Replace("MERGE", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Select) == StatementTypes.Select)
        //            regExText = regExText.Replace("SELECT", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Union) == StatementTypes.Union)
        //            regExText = regExText.Replace("UNION", string.Empty);
        //        if ((authorizedStatements & StatementTypes.Update) == StatementTypes.Update)
        //            regExText = regExText.Replace("UPDATE", string.Empty);

        //        //Remove extra separators
        //        RegexOptions regExOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline;
        //        regExText = Regex.Replace(regExText, "\\(\\|", "(", regExOptions);
        //        regExText = Regex.Replace(regExText, "\\|{2,}", "|", regExOptions);
        //        regExText = Regex.Replace(regExText, "\\|\\)", ")", regExOptions);

        //        //Check for errors
        //        MatchCollection patternMatchList = Regex.Matches(commandText, regExText, regExOptions);
        //        for (int patternIndex = patternMatchList.Count - 1; patternIndex >= 0; patternIndex += -1)
        //        {
        //            string value = patternMatchList[patternIndex].Value.Trim();
        //            if (string.IsNullOrWhiteSpace(value))
        //            {
        //                //Continue - Not an error.
        //            }
        //            else if (value.StartsWith("'") && value.EndsWith("'"))
        //            {
        //                //Continue - Text Block
        //            }
        //            else if (value.Trim() == ";")
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        isValid = false;

        //    }

        //    return isValid;
        //}



        public static bool ValidateStatement(out string ParamName, params string[] commandText)
        {
            bool isValid = false;

            Regex r = new Regex(@"[""`\'/]");
            foreach (var i in commandText)
            {
                if (r.IsMatch(i))
                {
                    ParamName = i;
                    return isValid;
                };

            }
            isValid = true;
            ParamName = null;
            return isValid;


        }
    }
}