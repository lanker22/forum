import React from "react";
import moment from "moment";
import { Link } from "react-router-dom";

var ThreadPreview = (props) => {
  var timeNow = new Date();
  var timePosted = new Date(props.thread.posts[0].timePosted);

  var timeElapsed = moment.utc(timeNow - timePosted).format("DD:HH:mm");

  const threadToLinkTo = `/thread/${props.thread.threadId}`;

  return (
    <div className="card mb-2">
      <div className="card-body p-2 p-sm-3">
        <div className="media forum-item">
          <a href="" data-toggle="collapse" data-target=".forum-content">
            <img
              src="https://bootdey.com/img/Content/avatar/avatar1.png"
              className="mr-3 rounded-circle"
              width="50"
              alt="User"
            />
          </a>
          <div className="media-body">
            <h6>
              <Link
                to={threadToLinkTo}
                data-toggle="collapse"
                className="text-body"
              >
                {props.thread.title}
              </Link>
            </h6>
            <p className="text-secondary">{props.thread.posts[0].content}</p>
            {props.thread.posts.length > 1 ? (
              <p className="text-muted">
                {
                  props.thread.posts[props.thread.posts.length - 1]
                    .applicationUser.userName
                }{" "}
                replied{" "}
                <span className="text-secondary font-weight-bold">
                  {timeElapsed} ago
                </span>
              </p>
            ) : (
              " "
            )}
          </div>
          <div className="text-muted small text-center align-self-center">
            <span className="d-none d-sm-inline-block">
              <i className="far fa-eye"></i>Replies{" "}
              {props.thread.posts.length - 1}
            </span>
            <span></span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ThreadPreview;
