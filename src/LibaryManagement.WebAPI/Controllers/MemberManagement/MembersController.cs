using LibaryManagement.BL.Abstractions.Member;
using LibaryManagement.Shared.Dtos.Member.Request;
using Microsoft.AspNetCore.Mvc;

namespace LibaryManagement.WebAPI.Controllers.MemberManagement;

[ApiController]
[Route("api/v1/members")]
public class MembersController(IMemberService memberService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMember([FromBody] MemberRequestDto memberRequestDto)
    {
        await memberService.CreateMember(memberRequestDto);

        return Created((string)null, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        return Ok(await memberService.GetMembers());
    }

    [HttpGet("{memberId:long}")]
    public async Task<IActionResult> GetMemberById([FromRoute] long memberId)
    {
        return Ok(await memberService.GetMemberById(memberId));
    }

    [HttpPut("{memberId:long}")]
    public async Task<IActionResult> UpdateMemberById(
        [FromRoute] long memberId,
        [FromBody] MemberRequestDto memberRequestDto)
    {
        return Ok(await memberService.UpdateMemberById(memberId, memberRequestDto));
    }

    [HttpDelete("{memberId:long}")]
    public async Task<IActionResult> DeleteMemberById([FromRoute] long memberId)
    {
        await memberService.DeleteMemberById(memberId);
        return NoContent();
    }
}
