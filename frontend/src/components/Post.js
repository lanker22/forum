import React from "react";

var Post = () => {
  return (
    <div className="card mb-2">
      <div className="card-body">
        <div className="media forum-item">
          <a href="" className="card-link">
            <img
              src="https://bootdey.com/img/Content/avatar/avatar1.png"
              className="rounded-circle"
              width="50"
              alt="User"
            />
            <small className="d-block text-center text-muted">Newbie</small>
          </a>
          <div className="media-body ml-3">
            <a href="" className="text-secondary">
              Mokrani
            </a>
            <small className="text-muted ml-2">1 hour ago</small>
            <h5 className="mt-1">Realtime fetching data</h5>
            <div className="mt-3 font-size-sm">
              <p>Hellooo :)</p>
              <p>
                I'm newbie with laravel and i want to fetch data from database
                in realtime for my dashboard anaytics and i found a solution
                with ajax but it dosen't work if any one have a simple solution
                it will be helpful
              </p>
              <p>Thank</p>
            </div>
          </div>
          <div className="text-muted small text-center">
            <span className="d-none d-sm-inline-block">
              <i className="far fa-eye"></i> 19
            </span>
            <span>
              <i className="far fa-comment ml-2"></i> 3
            </span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Post;
