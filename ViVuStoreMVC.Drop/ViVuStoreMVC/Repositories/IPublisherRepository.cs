﻿using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers();
    }
}