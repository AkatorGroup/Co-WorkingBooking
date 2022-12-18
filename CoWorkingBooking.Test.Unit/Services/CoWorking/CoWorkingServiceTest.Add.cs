﻿using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using FluentAssertions;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.CoWorking
{
    public partial class CoWorkingServiceTest
    {
        [Fact]
        public async ValueTask ShouldCreateCoWorking()
        {
            // given

            CoWorkingForCreationDTO randomCoWorking = CreateRandomCoWorking(new CoWorkingForCreationDTO());

            BranchForCreationDTO randomBranch = CreateRandomBranch(new BranchForCreationDTO());
            // when

            var createdBranch = await branchService.CreateAsync(randomBranch);

            randomCoWorking.BranchId = createdBranch.Id;

            var createdCoWorking = await coWorkingService.CreateAsync(randomCoWorking);

            // then

            createdBranch.Should().NotBeNull();
            createdCoWorking.Should().NotBeNull();

            createdCoWorking.Floor.Should().Be(randomCoWorking.Floor);
        }
    }
}
