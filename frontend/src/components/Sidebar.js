import React from 'react'

var Sidebar = () => {
    return (
        <div>
        <div className="inner-sidebar">
            <div className="inner-sidebar-header justify-content-center">
                <button className="btn btn-primary has-icon btn-block" type="button" data-toggle="modal" data-target="#threadModal">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" className="feather feather-plus mr-2">
                        <line x1="12" y1="5" x2="12" y2="19"></line>
                        <line x1="5" y1="12" x2="19" y2="12"></line>
                    </svg>
                    NEW DISCUSSION
                </button>
            </div>

            <div className="inner-sidebar-body p-0">
                <div className="p-3 h-100" data-simplebar="init">
                    <div className="simplebar-wrapper" style="margin: -16px;">
                        <div className="simplebar-height-auto-observer-wrapper"><div className="simplebar-height-auto-observer"></div></div>
                        <div className="simplebar-mask">
                            <div className="simplebar-offset" style="right: 0px; bottom: 0px;">
                                <div className="simplebar-content-wrapper" style="height: 100%; overflow: hidden scroll;">
                                    <div className="simplebar-content" style="padding: 16px;">
                                        <nav className="nav nav-pills nav-gap-y-1 flex-column">
                                            <a href="javascript:void(0)" className="nav-link nav-link-faded has-icon active">All Threads</a>
                                            <a href="javascript:void(0)" className="nav-link nav-link-faded has-icon">Popular this week</a>
                                            <a href="javascript:void(0)" className="nav-link nav-link-faded has-icon">Popular all time</a>
                                            <a href="javascript:void(0)" className="nav-link nav-link-faded has-icon">Solved</a>
                                            <a href="javascript:void(0)" className="nav-link nav-link-faded has-icon">Unsolved</a>
                                            <a href="javascript:void(0)" className="nav-link nav-link-faded has-icon">No replies yet</a>
                                        </nav>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="simplebar-placeholder" style="width: 234px; height: 292px;"></div>
                    </div>
                    <div className="simplebar-track simplebar-horizontal" style="visibility: hidden;"><div className="simplebar-scrollbar" style="width: 0px; display: none;"></div></div>
                    <div className="simplebar-track simplebar-vertical" style="visibility: visible;"><div className="simplebar-scrollbar" style="height: 151px; display: block; transform: translate3d(0px, 0px, 0px);"></div></div>
                </div>
            </div>
        </div>
        </div>
    );
}


export default Sidebar;