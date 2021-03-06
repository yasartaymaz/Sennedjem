﻿using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.UserClaims.Commands
{
  public class CreateUserClaimCommand : IRequest<IResult>
  {
    public int UserId { get; set; }
    public int ClaimId { get; set; }
    public class CreateUserClaimCommandHandler : IRequestHandler<CreateUserClaimCommand, IResult>
    {
      private readonly IUserClaimDal _userClaimDal;

      public CreateUserClaimCommandHandler(IUserClaimDal userClaimDal)
      {
        _userClaimDal = userClaimDal;
      }

      public async Task<IResult> Handle(CreateUserClaimCommand request, CancellationToken cancellationToken)
      {
        var userClaim = new UserClaim
        {
          ClaimId = request.ClaimId,
          UserId = request.UserId
        };
        await _userClaimDal.AddAsync(userClaim);

        return new SuccessResult(Messages.UserClaimCreated);
      }
    }
  }
}
