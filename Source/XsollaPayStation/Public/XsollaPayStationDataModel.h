﻿// Copyright 2020 Xsolla Inc. All Rights Reserved.

#pragma once

#include "XsollaPayStationDataModel.generated.h"

USTRUCT(BlueprintType)
struct XSOLLAPAYSTATION_API FXsollaPayStationPrice
{
	GENERATED_USTRUCT_BODY()

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString currency;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	float amount;

	FXsollaPayStationPrice()
		: amount(0.0f) {};
};

USTRUCT(BlueprintType)
struct XSOLLAPAYSTATION_API FXsollaPayStationVirtualCurrencyPackage
{
	GENERATED_USTRUCT_BODY()

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString currency;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	float quantity;

	FXsollaPayStationVirtualCurrencyPackage()
		: quantity(0.0f) {};
};

USTRUCT(BlueprintType)
struct XSOLLAPAYSTATION_API FXsollaPayStationItem
{
	GENERATED_USTRUCT_BODY()

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString sku;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString type;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString display_name;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString description;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FString image_url;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FXsollaPayStationPrice price;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Item")
	FXsollaPayStationVirtualCurrencyPackage bundle_content;
};

USTRUCT(BlueprintType)
struct XSOLLAPAYSTATION_API FXsollaPayStationItemToPurchase
{
	GENERATED_USTRUCT_BODY()

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Purchase")
	FString sku;

	UPROPERTY(BlueprintReadWrite, Category = "Xsolla PayStation Purchase")
	int32 amount;

	FXsollaPayStationItemToPurchase() 
		: amount(0) {};
};

USTRUCT(BlueprintType)
struct XSOLLAPAYSTATION_API FXsollaPayStationPurchaseStatus
{
	GENERATED_USTRUCT_BODY()

	UPROPERTY(BlueprintReadOnly, Category = "Xsolla PayStation Order")
	int32 id;

	UPROPERTY(BlueprintReadOnly, Category = "Xsolla PayStation Order")
	FString status;

	UPROPERTY(BlueprintReadOnly, Category = "Xsolla PayStation Order")
	FString external_id;

	FXsollaPayStationPurchaseStatus()
		: id(0) {};
};