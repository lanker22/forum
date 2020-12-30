import React from "react";

var NewThread = () => {
  return (
    <div
      className="modal fade"
      id="threadModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="threadModalLabel"
      aria-hidden="true"
    >
      <div className="modal-dialog modal-lg" role="document">
        <div className="modal-content">
          <form>
            <div className="modal-header d-flex align-items-center bg-primary text-white">
              <h6 className="modal-title mb-0" id="threadModalLabel">
                New Discussion
              </h6>
              <button
                type="button"
                className="close"
                data-dismiss="modal"
                aria-label="Close"
              >
                <span aria-hidden="true">×</span>
              </button>
            </div>
            <div className="modal-body">
              <div className="form-group">
                <label for="threadTitle">Title</label>
                <input
                  type="text"
                  className="form-control"
                  id="threadTitle"
                  placeholder="Enter title"
                  autofocus=""
                />
              </div>
              <textarea className="form-control summernote"></textarea>

              <div
                className="custom-file form-control-sm mt-3"
                style={{ maxWidth: 300 }}
              >
                <input
                  type="file"
                  className="custom-file-input"
                  id="customFile"
                  multiple=""
                />
                <label className="custom-file-label" for="customFile">
                  Attachment
                </label>
              </div>
            </div>
            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-light"
                data-dismiss="modal"
              >
                Cancel
              </button>
              <button type="button" className="btn btn-primary">
                Post
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default NewThread;
