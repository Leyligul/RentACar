﻿using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListBrand;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetByIdBrandQuery
{
    //Tek bir nesne döndüreceği için bir sayfalandırma yok. O yüzden 
    //Model içine koymadık Dto' yu. Ama duruma göre gerekedebilir.
    public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetByIdBrandQueryHandler (IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellation)
            {
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
                _brandBusinessRules.BrandShouldExistWhenRequested(brand);
                BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);
                return brandGetByIdDto;
                
            }
        }
    }
}