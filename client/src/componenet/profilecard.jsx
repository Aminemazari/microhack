import React from 'react'
import photo from "../assets/photo.svg"
import style from "./style.module.css"
const profilecard = ({pics,username}) => {
    if (pics==""){
        pics=photo;
    }
  return (
    <div className={style.profilecard}>
      <img src={pics}></img>
      <p className={style.username}>{username}</p>
    </div>
  )
}

export default profilecard
