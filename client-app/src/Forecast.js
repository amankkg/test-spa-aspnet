function Forecast(props) {
  return (
    <p>
      {props.index + 1}) {props.date} - {props.temperatureC}°, {props.summary}
    </p>
  )
}

export default Forecast
