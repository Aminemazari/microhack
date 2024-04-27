import React from 'react'
import style from "./style.module.css"
import dashboard_icon from "../assets/dashboard.svg"
import document_icon from "../assets/documents.svg"
import edit_icon from "../assets/edit.svg"
import group_icon from "../assets/group.svg"
import icon_icon from "../assets/Icon.svg"
import setting_icon from "../assets/setting.svg"
import signout_icon from "../assets/signout.svg"
import statistique_icon from "../assets/statistique.svg"
import user_icon from "../assets/user.svg"

const navigationBar = ({dashboardCliked,singoutonclick,singoutclicked,individualclicked,groupclicked,documentationclicked,statistiqueclicked,parameterclicked,dashboardonclick,individualonclick,documentationonclick,grouponclick,statistiqueonclick,parameteronclick}) => {
  return (
    <div className={style.navigationBar}>
    <section className={style.countainerOfButton}>
         <button className={style.menuButton}><img src={icon_icon}></img></button>
         <button className={style.edit}><img src={edit_icon}></img></button>
    </section>
      <section className={style.seperate}>
            <button className={`${style.dashboard } ${!dashboardCliked ? style.commanButtonNavigationButton: ''}`} onClick={dashboardonclick}><img src={dashboard_icon}></img></button>

        <button className={`${style.dashboard} ${!individualclicked ? style.commanButtonNavigationButton: ''}`} onClick={individualonclick}><img src={user_icon} className={style.icon}></img></button>
        <button className={`${ style.dashboard} ${!documentationclicked  ? style.commanButtonNavigationButton : ''}`} onClick={documentationonclick}><img src={document_icon} className={style.icon}></img></button>
        <button className={`${ style.dashboard} ${!groupclicked ? style.commanButtonNavigationButton: ''}`} onClick={grouponclick}><img src={group_icon} className={style.icon}></img></button> 
        <button className={`${ style.dashboard} ${!statistiqueclicked ? style.commanButtonNavigationButton: ''}`} onClick={statistiqueonclick}><img src={statistique_icon} className={style.icon}></img></button>
        <button className={`${ style.dashboard} ${!parameterclicked ? style.commanButtonNavigationButton: ''}`} onClick={parameteronclick}><img src={setting_icon} className={style.icon}></img></button>
        <button className={`${ style.dashboard} ${!singoutclicked ? style.commanButtonNavigationButton: ''}`} onClick={singoutonclick}><img src={signout_icon} className={style.icon}></img></button>
    </section>

    </div>
  )
}

export default navigationBar
