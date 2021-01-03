import React, { useState } from "react";

var Sidebar = () => {

  const [authenticated, setAuthenticated] = useState(localStorage.getItem("authenticated"));
  const [username, setUsername] = useState(localStorage.getItem("username"));

  const logout = async () => {
    var url = "http://localhost:5000/api/users/logout";
    var requestOptions = {
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
    };
    var response = await fetch(url, requestOptions);
    if (response.status !== 200) {
      return alert("Something went wrong. Try again.");
    } else {
      try {
        localStorage.removeItem("authenticated");
        localStorage.setItem("username", "");
        setAuthenticated(false);
        setUsername("");
      } catch (err) {
        console.log(err.Message);
        return alert("Something went wrong. Try again");
      }
    }
  };

  return (
    <div className="inner-sidebar">
      <div className="inner-sidebar-header justify-content-center">
        <button
          className="btn btn-primary has-icon btn-block"
          type="button"
          data-toggle="modal"
          data-target="#threadModal"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
            className="feather feather-plus mr-2"
          >
            <line x1="12" y1="5" x2="12" y2="19"></line>
            <line x1="5" y1="12" x2="19" y2="12"></line>
          </svg>
          NEW DISCUSSION
        </button>
      </div>

      <div className="inner-sidebar-body p-0">
        <div className="p-3 h-100" data-simplebar="init">
          <div className="simplebar-wrapper" style={{ margin: -16 }}>
            <div className="simplebar-height-auto-observer-wrapper">
              <div className="simplebar-height-auto-observer"></div>
            </div>
            <div className="simplebar-mask">
              <div className="simplebar-offset" style={{ right: 0, bottom: 0 }}>
                <div
                  className="simplebar-content-wrapper"
                  style={{ height: 100 }}
                >
                  <div className="simplebar-content" style={{ padding: 16 }}>
                    {authenticated !== false ? (
                      <nav className="nav nav-pills nav-gap-y-1 flex-column">
                        <span className="nav-link nav-link-faded has-icon">
                          {username}
                        </span>
                        <a
                          href="/"
                          className="nav-link nav-link-faded has-icon"
                        >
                          Home
                        </a>
                        <a
                          href=""
                          onClick={logout}
                          className="nav-link nav-link-faded has-icon"
                        >
                          Logout
                        </a>
                        <a href="" className="nav-link nav-link-faded has-icon">
                          Edit Profile
                        </a>
                        <a href="" className="nav-link nav-link-faded has-icon">
                          My Threads
                        </a>
                        <a href="" className="nav-link nav-link-faded has-icon">
                          My Posts
                        </a>
                      </nav>
                    ) : (
                      <nav className="nav nav-pills nav-gap-y-1 flex-column">
                        <a href="" class="nav-link nav-link-faded has-icon">
                          Home
                        </a>
                        <a
                          href="/login"
                          class="nav-link nav-link-faded has-icon"
                        >
                          Login
                        </a>
                        <a
                          href="/register"
                          class="nav-link nav-link-faded has-icon"
                        >
                          Register
                        </a>
                      </nav>
                    )}
                  </div>
                </div>
              </div>
            </div>
            <div
              className="simplebar-placeholder"
              style={{ width: 234, height: 292 }}
            ></div>
          </div>
          <div
            className="simplebar-track simplebar-horizontal"
            style={{ visibility: "hidden" }}
          >
            <div
              className="simplebar-scrollbar"
              style={{ width: 0, display: "none" }}
            ></div>
          </div>
          <div
            className="simplebar-track simplebar-vertical"
            style={{ visibility: "visible" }}
          >
            <div
              className="simplebar-scrollbar"
              style={{
                height: 151,
                display: "block",
                transform: "translate3d(0, 0, 0)",
              }}
            ></div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
