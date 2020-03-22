﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CapCube
{
    class Battler
    {
        public Specter Specter;
        BattlerSprite BattlerSprite;
        int BattlerIndex;
        Vector2 TilePos = new Vector2(0, 0);
        public bool IsMoving = false;
        bool isMovingX = false;
        bool isMovingY = false;
        decimal movementCount = 0;
        Vector2 dir = new Vector2(0,0);

        public Battler(Specter specter, int index)
        {
            Specter = specter;
            BattlerSprite = new BattlerSprite(specter);
            BattlerIndex = index;
            if (!IsOpponent()) {
                SetTilePosition(1, 1); 
            }
            else
            {
                BattlerSprite.Flip();
                SetTilePosition(1, 4);
            }
        }

        public void Update()
        {
            if (isMovingX)
            {
                movementCount += 8 * (decimal) dir.X;
                BattlerSprite.SetPosition(GetRealPos(TilePos).X + (float) movementCount, GetRealPos(TilePos).Y);
                if (movementCount == 80 || movementCount == -80)
                {
                    SetTilePosition((int)TilePos.Y, (int)(TilePos.X + dir.X));
                    isMovingX = false;
                    movementCount = 0;
                }
            }
            else if (isMovingY)
            {
                movementCount += (decimal) (5.4 * dir.Y);
                BattlerSprite.SetPosition(GetRealPos(TilePos).X, GetRealPos(TilePos).Y + (float) movementCount);
                if ((movementCount == 54) || (movementCount == -54))
                {
                    SetTilePosition((int)(TilePos.Y + dir.Y), (int) TilePos.X);
                    isMovingY = false;
                    movementCount = 0;
                }
            }
            
        }

        public void Move(int XDistance, int YDistance, CCMovement.Movement movementType = CCMovement.Movement.Normal)
        {
            if (!IsMoving && CanMoveTo(new Vector2(XDistance, YDistance))){
                switch (movementType)
                {
                    case (CCMovement.Movement.Normal):
                        dir = new Vector2(XDistance, YDistance);
                        if (XDistance != 0)
                        {
                            IsMoving = true;
                            isMovingX = true;
                        }
                        else if (YDistance != 0)
                        {
                            IsMoving = true;
                            isMovingY = true;
                        }
                        break;
                    case (CCMovement.Movement.Teleport):
                        IsMoving = true;
                        SetTilePosition((int) TilePos.Y + YDistance, (int) TilePos.X + XDistance);
                        break;
                }
            }
        }

        public bool IsOpponent()
        {
            return BattlerIndex > 0;
        }


        public void Draw()
        {
            BattlerSprite.Draw();
        }

        public void SetTilePosition(int row, int col)
        {
            TilePos.X = col;
            TilePos.Y = row;
            Vector2 newPos = GetRealPos(TilePos);
            BattlerSprite.SetPosition(newPos.X, newPos.Y);
            IsMoving = false;
        }

        public Vector2 GetRealPos(Vector2 tilePos)
        {
            float originX = 80 * tilePos.X;
            float originY = 108 + 54 * tilePos.Y;
            return new Vector2(originX + 38, originY + 32);
        }

        public bool CanMoveTo(Vector2 distance)
        {
            bool result = true;
            int newX = (int)(TilePos.X + distance.X);
            int newY = (int)(TilePos.Y + distance.Y);

            //Left bound (player)
            if (newX < 0)
            {
                return false;
            }
            //Right bound (player)
            if (newX >= 3 && !IsOpponent())
            {
                return false;
            }
            //Left bound (opponent)
            if (newX <= 2 && IsOpponent())
            {
                return false;
            }
            //Right bound (opponent)
            if (newX >= 9 && IsOpponent())
            {
                return false;
            }
            //Top bound
            if (newY < 0)
            {
                return false;
            }
            //Bottom bound
            if (newY >= 3)
            {
                return false;
            }

            return result;
        }
    }
}