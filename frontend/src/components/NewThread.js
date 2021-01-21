import React, { useState } from "react";
import { useHistory } from "react-router-dom";

var NewThread = () => {
  const history = useHistory();
  const [threadTitle, setThreadTitle] = useState();
  const [openingPost, setOpeningPost] = useState();

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Title: threadTitle,
      OpeningPost: openingPost,
      TimeCreated: new Date().toISOString(),
    }),
    credentials: "include",
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await fetch("http://localhost:5000/api/thread/create", requestOptions);
      window.$("#threadModal").modal("hide");
      history.push("/");
      history.go(0);
    } catch (err) {
      console.log(err);
      return alert("Something went wrong. Please try again");
    }
  };

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
          <form onSubmit={handleSubmit}>
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
                <label htmlFor="threadTitle">Title</label>
                <input
                  type="text"
                  className="form-control"
                  id="threadTitle"
                  placeholder="Enter title"
                  autoFocus=""
                  required
                  value={threadTitle}
                  onChange={(e) => setThreadTitle(e.target.value)}
                />
                <label htmlFor="openingPost">Opening post</label>
                <input
                  type="text"
                  className="form-control"
                  id="openingPost"
                  placeholder="Enter OP"
                  autoFocus=""
                  required
                  value={openingPost}
                  onChange={(e) => setOpeningPost(e.target.value)}
                />
              </div>
            </div>
            <div className="modal-footer">
              <button
                type="submit"
                className="btn btn-light"
                data-dismiss="modal"
              >
                Cancel
              </button>
              <button type="submit" className="btn btn-primary">
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
