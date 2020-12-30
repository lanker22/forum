import React from 'react'

var Search = () => {
    return (
        <div className="inner-main-header">
        <a className="nav-link nav-icon rounded-circle nav-link-faded mr-3 d-md-none" href="#" data-toggle="inner-sidebar"><i className="material-icons">arrow_forward_ios</i></a>
        <select className="custom-select custom-select-sm w-auto mr-1">
            <option selected="">Latest</option>
            <option value="1">Popular</option>
            <option value="3">No Replies Yet</option>
        </select>
        <span className="input-icon input-icon-sm ml-auto w-auto">
            <input type="text" className="form-control form-control-sm bg-gray-200 border-gray-200 shadow-none mb-4 mt-4" placeholder="Search forum" />
        </span>
    </div>
    )
}

export default Search;