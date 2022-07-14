﻿using Microsoft.AspNetCore.Mvc;
using MiroWebPlugin.Models;
using MiroWebPlugin.Provider;

namespace MiroWebPlugin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiroWebPluginController : ControllerBase
    {

        #region Dependencies

        private readonly IInputFieldProvider _inputFieldProvider;

        public MiroWebPluginController(IInputFieldProvider inputFieldProvider)
        {
            _inputFieldProvider = inputFieldProvider;
        }

        #endregion
        [HttpGet("[action]")]
        public IActionResult CreateNewSession()
        {
            return new ObjectResult(12345);
        }

        [HttpPost("[action]")]
        public IActionResult InitFields([FromQuery] string[] ids )
        {
            var sessionId = _inputFieldProvider.InitFields(ids);

            return new ObjectResult(sessionId);
        }

        [HttpPut("[action]")]
        public IActionResult AddStickyNote([FromBody] StickyNoteAddRequest request)
        {
            _inputFieldProvider.AddStickyNote(request);
            return new NoContentResult();
        }

        [HttpGet("[action]")]
        public IActionResult LoadSessionViewModel()
        {
            var sessionViewModel = new SessionViewModel();
            sessionViewModel.InputFields = _inputFieldProvider.GetLoadedInputFields();
            return new ObjectResult(sessionViewModel);
        }
    }
}