import React from 'react'
import style from "./styleTwo.module.css"
import classNames from 'classnames'
import done from "../assets/doneIcon.svg"
import pending from "../assets/pending.svg"
import inprogres from "../assets/inprogress.png"
import discard from "../assets/discard.svg"
import add from "../assets/add.svg"
import generateIcon from "../assets/ia.svg"
const iaCard = ({projectTitle,campanyName,campanyPics,onclickGenerate,onclickTaskWithIa,title,status}) => {
    var photo; 
    if (status=="inprogress"){
        photo=inprogres;
    }
    else if (status=="done"){
        photo=done;
    }
    else if (status=="pending"){
       photo=pending;
    }
    else if (status=="discard"){
        photo=discard;
    }

  return (
    <div className={style.iaCard}>
        <section className={style.cardInfo}>
            <mark className={style.cardStatus}>
                 <p className={style.projectTitle}>{projectTitle}</p>
                 <img src={photo}/>
            </mark>
            <p className={style.title}>{title}</p>
            <div className={style.campanyinfo}>
                <img src={campanyPics}/>
                <p className={style.campanyName}>{campanyName}</p>
            </div>
        </section>
        <section className={style.buttonAi}>
            <button className={style.generateButton} onClick={onclickGenerate}><img src={add}></img>Generate Tasks</button>
            <button className={style.taskAi} onClick={onclickTaskWithIa}><img src={generateIcon}></img>Tasks With AI</button>

        </section>
      
    </div>
  )
}

export default iaCard
