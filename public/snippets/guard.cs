// refer to https://github.com/ardalis/GuardClauses/tree/main

public interface IGuardClause { }
  
public class Guard : IGuardClause
{
  private Guard() { }
  
  public static IGuardClause Against { get; } = new Guard();
}

public static class GuardClauseExtensions
{
    public static T Null<T>(this IGuardClause guardClause, T input, string parameterName)
    {
        if (input is null)
            throw new ArgumentNullException(parameterName);

        return input;
    }
}