using AutoMapper;
using WorkingTime.Application.Common.Mappings;

namespace WorkingTime.Application.Features.WorkingSession.Queries.GetWorkingSessionList
{
    public class WorkingSessionLookupDto : IMapWith<Domain.Models.WorkingSession>
    {
        public int Id { get; set; }
        public int TotalWorkingTime { get; set; }
        public DateTime StartWorkSession { get; set; }
        public DateTime GroupDate { get; set; }
        public DateTime? EndWorkSession { get; set; }
        public decimal? PerfomanceEvalution { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.WorkingSession, WorkingSessionLookupDto>()
                .ForMember(wsDto => wsDto.Id,
                    opt => opt.MapFrom(ws => ws.Id))
                .ForMember(wsDto => wsDto.TotalWorkingTime,
                    opt => opt.MapFrom(ws => ws.TotalWorkingTime))
                .ForMember(wsDto => wsDto.StartWorkSession,
                    opt => opt.MapFrom(ws => ws.StartWorkingDay))
                .ForMember(wsDto => wsDto.GroupDate,
                    opt => opt.MapFrom(ws => ws.StartWorkingDay.Date))
                .ForMember(wsDto => wsDto.EndWorkSession,
                    opt => opt.MapFrom(ws => ws.EndWorkingDay))
                .ForMember(wsDto => wsDto.PerfomanceEvalution,
                    opt => opt.MapFrom(ws => ws.PerformanceEvaluation));
        }
    }
}
