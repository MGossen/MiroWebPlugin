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
            string id = _inputFieldProvider.AddStickyNote(request);
            var result = new AddStickyNoteResult();
            result.Id = id;
            return new ObjectResult(result);
        }

        [HttpGet("[action]/{sessionId:int}")]
        public IActionResult LoadSessionViewModel(int sessionId)
        {
            var sessionViewModel = new SessionViewModel();
            sessionViewModel.SessionId = sessionId;
            sessionViewModel.InputFields = _inputFieldProvider.GetLoadedInputFields(sessionId);
            return new ObjectResult(sessionViewModel);
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteStickyNote(string id)
        {
            _inputFieldProvider.DeleteStickyNote(id);
            return new NoContentResult();
        }
    }
}
