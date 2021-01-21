import React, { useContext } from "react";
import UserContext from "./UserContext";
import { useHistory, Link } from "react-router-dom";

var Sidebar = () => {
  const history = useHistory();
  const [user, setUser] = useContext(UserContext);

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
        localStorage.setItem("user", "");
        setUser("");
      } catch (err) {
        console.log(err.Message);
        return alert("Something went wrong. Try again");
      }
    }
  };

  return (
    <div className="inner-sidebar">
      <div className="inner-sidebar-header justify-content-center">
        {user !== "" ? (
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
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
              className="feather feather-plus mr-2"
            >
              <line x1="12" y1="5" x2="12" y2="19"></line>
              <line x1="5" y1="12" x2="19" y2="12"></line>
            </svg>
            NEW DISCUSSION
          </button>
        ) : (
          <button
            className="btn btn-primary has-icon btn-block"
            type="button"
            onClick={() => {
              history.push("/login");
            }}
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
              className="feather feather-plus mr-2"
            >
              <line x1="12" y1="5" x2="12" y2="19"></line>
              <line x1="5" y1="12" x2="19" y2="12"></line>
            </svg>
            NEW DISCUSSION
          </button>
        )}
      </div>

      <div className="inner-sidebar-body p-0">
        <div className="p-3 h-100" dataSimplebar="init">
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
                    {user !== "" ? (
                      <nav className="nav nav-pills nav-gap-y-1 flex-column">
                        <span className="nav-link nav-link-faded has-icon">
                          {user}
                        </span>
                        <a
                          href={"/"}
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
                      </nav>
                    ) : (
                      <nav className="nav nav-pills nav-gap-y-1 flex-column">
                        <a
                          href={"/"}
                          className="nav-link nav-link-faded has-icon"
                        >
                          Home
                        </a>
                        <a
                          href="/login"
                          className="nav-link nav-link-faded has-icon"
                        >
                          Login
                        </a>
                        <a
                          href="/register"
                          className="nav-link nav-link-faded has-icon"
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
