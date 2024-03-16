# Railway Result

Implementation of a **Result Pattern** for C# with functional extension methods leveraging **Railway Oriented Programming**. Learn more about [Railway Oriented Programming](https://fsharpforfunandprofit.com/rop/).

Extension Methods:

- `Ensure` and `EnsureNotNull` - tests for condition resulting in succedded/failed result object (railway).
- `Then` - maps current value of result object to a new value (on succeeded railway).
- `Tap` - invokes funcion on value of result object (on succeeded railway).
- `And` - encapsulates additional value into result object (on succeeded railway).

### Example:
```csharp
public Result SetMemberRole(Guid initiatorId, Guid memberId, TeamRole newRole)
{
   return newRole
      .Ensure(role => !role.IsOwner(), Errors.CannotHaveMultipleTeamOwners)
      .Then(_ => GetTeamMemberByUserId(initiatorId))
      .Ensure(member => member.Role.CanUpdateTeamRoles(), Errors.ForbiddenToUpdateTeamRoles)
      .Then(_ => GetTeamMember(memberId))
      .Ensure(member => !member.Role.IsOwner(), Errors.ForbiddenToChangeTeamOwnersRole)
      .Tap(member => member.UpdateRole(newRole))
      .ToResult();
}

public Result<TeamMember> GetTeamMemberByUserId(Guid userId)
{
   var member = _members.Find(member => member.UserId == userId);
   return member.EnsureNotNull(Errors.NotMemberOfTeam);
}

public Result<TeamMember> GetTeamMember(Guid memberId)
{
   var member = _members.Find(member => member.Id == memberId);
   return member.EnsureNotNull(Errors.MemberNotFound);
}
```

### Result Pattern without using railway-oriented programing:
```csharp
public Result SetMemberRole(Guid initiatorId, Guid memberId, TeamRole newRole)
{
   if (newRole.IsOwner())
      return Errors.CannotHaveMultipleTeamOwners;

   var initiator = GetTeamMemberByUserId(initiatorId);
   if (initiator is null)
      return Errors.NotMemberOfTeam;

   if (!initiator.Role.CanUpdateTeamRoles())
      return Errors.ForbiddenToUpdateTeamRoles;

   var member = GetTeamMember(memberId);
   if (membe is null)
      return Errors.MemberNotFound;

   if (member.Role.IsOwner())
      return Errors.ForbiddenToChangeTeamOwnersRole;

   member.UpdateRole(newRole);
   return Result.Success;
}

public TeamMember? GetTeamMemberByUserId(Guid userId)
{
   return _members.Find(member => member.UserId == userId);
}

public TeamMember? GetTeamMember(Guid memberId)
{
   return _members.Find(member => member.Id == memberId);
}
```

*Note: using railway-oriented programming results in cleaner and shorter code, however, it also brings additional overhead and inability to return early from function, thus making it less performant.*

*Learn more about [when to not use railway-oriented programming](https://fsharpforfunandprofit.com/posts/against-railway-oriented-programming/).*