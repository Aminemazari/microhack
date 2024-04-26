import React from 'react'
import { Bar } from 'react-chartjs-2';
import { Utils } from 'chart.js';

const  BarChartBorderRadius = () => {

  return (
    <div>
      <Bar data={data} actions={actions} />
    </div>
  )
}

export default  BarChartBorderRadius
