using AutoMapper;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public class ReplyManager : IReplyService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ReplyManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ReplyDto> CreateReplyAsync(ReplyDtoForInsertion replyDto)
        {
            var entity = _mapper.Map<Reply>(replyDto);
            _manager.Reply.CreateReply(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ReplyDto>(entity);
        }

        public async Task DeleteReplyAsync(int replyId, bool trackChanges)
        {
            var entity = await _manager.Reply.GetReplyByReplyIdAsync(replyId, trackChanges);
            //if (entity is null)
            //{
            //    throw new ReplyNotFoundByReplyIdException(replyId);
            //}
            _manager.Reply.DeleteReply(entity);
            await _manager.SaveAsync();
        }

        public async Task<ReplyDto> GetReplyByReplyIdAsync(int replyId, bool trackChanges)
        {
            var reply = await _manager.Reply.GetReplyByReplyIdAsync(replyId, trackChanges);
            //if (reply is null)
            //    throw new ReplyNotFoundByReplyIdException(replyId);

            return _mapper.Map<ReplyDto>(reply);
        }

        public async Task<IEnumerable<ReplyDto>> GetRepliesByReviewIdAsync(int reviewId, bool trackChanges)
        {
            var replies = await _manager.Reply.GetRepliesByReviewIdAsync(reviewId, trackChanges);
            //if (replies is null)
            //    throw new RepliesNotFoundByReviewIdException(reviewId);

            return _mapper.Map<IEnumerable<ReplyDto>>(replies);
        }

        public async Task UpdateReplyAsync(int replyId, ReplyDtoForUpdate replyDto, bool trackChanges)
        {
            var entity = await _manager.Reply.GetReplyByReplyIdAsync(replyId, trackChanges);
            //if (entity is null)
            //    throw new ReplyNotFoundByReplyIdException(replyId);

            entity = _mapper.Map<Reply>(replyDto);

            _manager.Reply.UpdateReply(entity);
            await _manager.SaveAsync();
        }
    }
}
