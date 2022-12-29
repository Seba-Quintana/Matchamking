import React from 'react'
import styled from 'styled-components'
import StyledBox from './BoxStyle'

const PlayerBox = styled(StyledBox)`
    display: flex;
    cursor: pointer;
    height: 50px;
    font-size: 16px;
    padding-top: 0.5rem;
    padding-bottom: 0.5rem;
    background-color: #e4e4e4;
    width: 100%;
    border-radius: 5px 5px 0px 0px;
`

const Winrate = styled.div`
  text-align: left;
  width: 25%;
  margin-left: 1rem;
`

const PlayerName = styled.div`
    text-align: left;
    width: 50%;
`

const Remove = styled.div`
   text-align: right;
    width: 25%;
  margin-right: 1rem;
`

const SelectedPlayer = (
  {winrate, nickname, setPlayerClicked}
) => {
  return (
    <PlayerBox>
      <Winrate>{winrate}</Winrate>
      <PlayerName>{nickname}</PlayerName>
      <Remove onClick={() => {
         return setPlayerClicked({
            nickname: nickname,
            winrate: winrate
        })
        }
      }>Quitar</Remove>
  </PlayerBox>
  )
}

export default SelectedPlayer