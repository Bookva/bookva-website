﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Work;
using Bookva.DAL;
using System.Threading.Tasks;
using Bookva.Business.ImageService;

namespace Bookva.Business
{
    public class WorksService : IWorksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public WorksService(IUnitOfWork uow, IImageService imageService)
        {
            _unitOfWork = uow;
            _imageService = imageService;
        }

        public WorkReadModel Get(int id)
        {
            var x = _unitOfWork.WorkRepository.Get(id);
            return x.ToReadModel();
        }

        public IEnumerable<WorkPreviewModel> GetAll()
        {
            return _unitOfWork.WorkRepository.Get().ToList().Select(WorksMapper.ToPreviewModel);
        }

        public IEnumerable<WorkPreviewModel> Get(PaginationOptions options)
        {
            return _unitOfWork.WorkRepository.Get().OrderBy(w => w.Id).Skip((options.Page - 1) * options.PageSize).Take(options.PageSize).ToList().Select(WorksMapper.ToPreviewModel);
        }

        public void Create(WorkWriteModel workDto)
        {
            var work = workDto.ToDB();
            foreach (var authorId in workDto.AuthorIds)
            {
                var author = _unitOfWork.AuthorRepository.Get(authorId);
                work.Authors.Add(author);
            }
            //TODO: add keywords and genres
            _unitOfWork.WorkRepository.Insert(work);
            _unitOfWork.Save();
        }

        public void Edit(WorkWriteModel workDto)
        {
            var work = workDto.ToDB();
            foreach (var authorId in workDto.AuthorIds)
            {
                var author = _unitOfWork.AuthorRepository.Get(authorId);
                work.Authors.Add(author);
            }
            //TODO: add keywords and genres
            _unitOfWork.WorkRepository.Update(work, work.Id);
            _unitOfWork.Save();
        }

        public async Task ChangePictureAsync(Image image, int id)
        {
            var work = _unitOfWork.WorkRepository.Get(id);
            var pictureTask = _imageService.UploadAsync(image, ImageType.UserPic, $"workId-{id}");
            var previewPictureTask = _imageService.UploadAsync(image, ImageType.Miniature, $"workId-{id}-mini");

            work.CoverSource = await pictureTask;
            work.PreviewCoverSource = await previewPictureTask;
            _unitOfWork.WorkRepository.Update(work, id);
            _unitOfWork.Save();
        }
    }
}
