﻿namespace CursoResidencia.Domain.Repository;

public interface ICursoRepository
{
    IEnumerable<Curso> GetAll();
}